// <copyright file="CreditReportBuilder.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using CreditsafeConnect.Models.CreditReportModels;
    using CreditsafeConnect.Models.CreditReportModels.Internal;

    /// <summary>
    /// Class used for converting from a <see cref="Report"/> object to a <see cref="CreditReportResult"/> object.
    /// </summary>
    internal class CreditReportBuilder
    {
        /// <summary>
        /// Creates a <see cref="CreditReportResult"/> from a <see cref="Report"/>.
        /// </summary>
        /// <param name="report"><see cref="Report"/> object to be converted to a <see cref="CreditReportResult"/>.</param>
        /// <returns><see cref="CreditReportResult"/> object.</returns>
        internal CreditReportResult BuildCreditReport(Report report)
        {
            CreditReportResult result = new CreditReportResult
            {
                CreditsafeId = report.CompanyId,
                Name = report.CompanySummary.BusinessName,
                Status = report.CompanySummary.CompanyStatus.Status,
                General = BuildGeneral(report),
                Financial = BuildFinancial(report),
            };

            return result;
        }

        /// <summary>
        /// Creates a <see cref="General"/> object from a <see cref="Report"/>.
        /// </summary>
        /// <param name="report"><see cref="Report"/> object from which to create a <see cref="General"/> object.</param>
        /// <returns><see cref="General"/> object.</returns>
        private static General BuildGeneral(Report report)
        {
            General general = new General
            {
                PhoneNumber = report.ContactInformation.MainAddress.Telephone,
            };

            if (!string.IsNullOrWhiteSpace(report.ContactInformation.MainAddress?.Street) ||
                string.IsNullOrWhiteSpace(report.ContactInformation.MainAddress?.City) ||
                string.IsNullOrWhiteSpace(report.ContactInformation.MainAddress?.PostalCode) ||
                string.IsNullOrWhiteSpace(report.ContactInformation.MainAddress?.Country))
            {
                if (!string.IsNullOrEmpty(report.ContactInformation.MainAddress?.AdditionToAddress))
                {
                    if (Regex.IsMatch(report.ContactInformation.MainAddress.AdditionToAddress, report.ContactInformation.MainAddress.HouseNumber, RegexOptions.IgnoreCase))
                    {
                        report.ContactInformation.MainAddress.AdditionToAddress = Regex
                            .Replace(report.ContactInformation.MainAddress.AdditionToAddress,
                                report.ContactInformation.MainAddress.HouseNumber, string.Empty,
                                RegexOptions.IgnoreCase).Trim();
                    }
                }

                general.VisitingAddress = report.ContactInformation.MainAddress;
            }
            else
            {
                general.VisitingAddress = null;
            }

            general.PostalAddress = report.ContactInformation.OtherAddresses?
                .FirstOrDefault(address => !string.IsNullOrWhiteSpace(address.Type) && Regex.IsMatch(address.Type, @"postal", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));

            if (!string.IsNullOrEmpty(general.PostalAddress?.AdditionToAddress))
            {
                if (Regex.IsMatch(general.PostalAddress.AdditionToAddress, general.PostalAddress.HouseNumber, RegexOptions.IgnoreCase))
                {
                    general.PostalAddress.AdditionToAddress = Regex.Replace(general.PostalAddress.AdditionToAddress,
                        general.PostalAddress.HouseNumber, string.Empty, RegexOptions.IgnoreCase).Trim();
                }
            }

            if (report.ContactInformation.EmailAddresses?.Length > 0)
            {
                general.Email = report.ContactInformation.EmailAddresses.FirstOrDefault(email =>
                    Regex.IsMatch(email, $"\\.{report.ContactInformation.MainAddress?.Country}", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)) ?? report.ContactInformation.EmailAddresses.FirstOrDefault();
            }

            if (report.ContactInformation.Websites?.Length > 0)
            {
                general.Website = report.ContactInformation.Websites.FirstOrDefault(website =>
                    Regex.IsMatch(website, $"\\.{report.ContactInformation.MainAddress?.Country}", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)) ?? report.ContactInformation.Websites.FirstOrDefault();
            }

            return general;
        }

        /// <summary>
        /// Creates a <see cref="Financial"/> object from a <see cref="Report"/>.
        /// </summary>
        /// <param name="report"><see cref="Report"/> object from which to create a <see cref="Financial"/> object.</param>
        /// <returns><see cref="Financial"/> object.</returns>
        private static Financial BuildFinancial(Report report)
        {
            Financial financial = new Financial
            {
                RegistrationNumber = report.CompanySummary.CompanyRegistrationNumber,
                RegistrationDate = report.CompanyIdentification.BasicInformation.CompanyRegistrationDate,
                StatutoryAddress = report.AdditionalInformation.Misc.StatutaireSeal,
                MainActivity = report.CompanySummary.MainActivity,
                CreditScore = report.CompanySummary.CreditRating?.CommonValue,
                Currency = report.CompanySummary.CreditRating?.CreditLimit.Currency ?? "EUR",
                VatNumber = report.CompanyIdentification.BasicInformation.VatRegistrationNumber,
            };

            if (decimal.TryParse(report.CompanySummary.CreditRating?.CreditLimit?.Value, out decimal creditLimit))
            {
                financial.CreditLimit = creditLimit;
            }

            if (!string.IsNullOrWhiteSpace(report.AdditionalInformation?.Misc?.RsinNumber))
            {
                // EORI Number = Country code + RSIN (if length < 9, keep APPENDING 0)
                string rsin = report.AdditionalInformation.Misc.RsinNumber;
                financial.EoriNumber = report.CompanySummary.Country + new string('0', 9 - rsin.Length > 0 ? 9 - rsin.Length : 0) + rsin;
            }

            financial.UltimateParent = report.GroupStructure?.UltimateParent;
            financial.ImmediateParent = report.GroupStructure?.ImmediateParent;

            string numberOfEmployees = report.OtherInformation?.EmployeesInformation?.OrderByDescending(
                employeeInformation => employeeInformation.Year).FirstOrDefault()?.NumberOfEmployees;

            if (!string.IsNullOrWhiteSpace(numberOfEmployees))
            {
                if (int.TryParse(numberOfEmployees, out int employeeCount))
                {
                    financial.Employees = employeeCount;
                }
                else if (numberOfEmployees.Contains("-"))
                {
                    List<double> numbers = (from Match match in Regex.Matches(numberOfEmployees, @"\d+") select double.Parse(match.Value)).ToList();

                    financial.Employees = Convert.ToInt32(Math.Round(numbers.Sum() / 2));
                }
            }

            switch (report.CompanySummary.BusinessName)
            {
                case string name when Regex.IsMatch(name, @"\b(BVBA|B\.?V\.?B\.?A\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "BVBA";
                    break;
                case string name when Regex.IsMatch(name, @"\b(BV|B\.?V\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "BV";
                    break;
                case string name when Regex.IsMatch(name, @"\b(NV|N\.?V\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "NV";
                    break;
                case string name when Regex.IsMatch(name, @"\b(VOF|V\.?O\.?F\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "VOF";
                    break;
                case string name when Regex.IsMatch(name, @"\b(GMBH|G\.?M\.?B\.?H\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "GMBH";
                    break;
                case string name when Regex.IsMatch(name, @"\b(PLC|P\.?L\.?C\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "PLC";
                    break;
                case string name when Regex.IsMatch(name, @"\b(LTD|L\.?T\.?D\.?|LIMITED)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "LTD";
                    break;
                case string name when Regex.IsMatch(name, @"\b(INC|I\.?N\.?C\.?|INCORPORATED)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "INC";
                    break;
                case string name when Regex.IsMatch(name, @"\b(SPRL|S\.?P\.?R\.?L\.?)\b", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase):
                    financial.LegalForm = "SPRL";
                    break;
            }

            return financial;
        }
    }
}
