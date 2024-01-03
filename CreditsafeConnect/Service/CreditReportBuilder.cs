// <copyright file="CreditReportBuilder.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Linq;
    using System.Text.RegularExpressions;
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
                CreditsafefId = report.CompanyId,
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
                Language = report.Language,
                VisitingAddress = report.ContactInformation.MainAddress,
                PostalAddress = report.ContactInformation.OtherAddresses
                    .FirstOrDefault(address => Regex.IsMatch(address.Type, @"postal", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)),
                PhoneNumber = report.ContactInformation.MainAddress.Telephone,
            };

            if (report.ContactInformation.Websites.Any(website =>
                    Regex.IsMatch(website, @"\.nl", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)))
            {
                general.Website = report.ContactInformation.Websites.FirstOrDefault(website =>
                    Regex.IsMatch(website, @"\.nl", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));
            }
            else
            {
                general.Website = report.ContactInformation.Websites.FirstOrDefault();
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
                CreditLimit = decimal.Parse(report.CompanySummary.CreditRating.CreditLimit.Value),
                CreditScore = report.CompanySummary.CreditRating.CommonValue,
                Currency = report.CompanySummary.CreditRating.CreditLimit.Currency,
            };

            // EORI Number = Country code + RSIN (if length < 9, keep APPENDING 0)
            string rsin = report.AdditionalInformation.Misc.RsinNumber;
            financial.EoriNumber = report.CompanySummary.Country + new string('0', 9 - rsin.Length > 0 ? 9 - rsin.Length : 0) + rsin;

            financial.UltimateParent = report.GroupStructure.UltimateParent;
            financial.ImmediateParent = report.GroupStructure.ImmediateParent;
            financial.Employees = int.Parse(report.OtherInformation.EmployeesInformation
                .OrderByDescending(employeeInformation => employeeInformation.Year).FirstOrDefault()
                ?.NumberOfEmployees ?? string.Empty);
            financial.LegalForm = report.CompanyIdentification.BasicInformation.LegalForm;

            return financial;
        }
    }
}
