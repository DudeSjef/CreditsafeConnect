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
    /// Class used for converting from a <see cref="CreditReport"/> object to a <see cref="CreditReportResult"/> object.
    /// </summary>
    internal class CreditReportBuilder
    {
        /// <summary>
        /// Creates a <see cref="CreditReportResult"/> from a <see cref="CreditReport"/>.
        /// </summary>
        /// <param name="creditReport"><see cref="CreditReport"/> object to be converted to a <see cref="CreditReportResult"/>.</param>
        /// <returns><see cref="CreditReportResult"/> object.</returns>
        internal CreditReportResult BuildCreditReport(CreditReport creditReport)
        {
            CreditReportResult result = new CreditReportResult
            {
                CreditsafefId = creditReport.Report.CompanyId,
                Name = creditReport.Report.CompanySummary.BusinessName,
                //Status = creditReport.Report.CompanySummary.CompanyStatus.Status,
                General = BuildGeneral(creditReport),
                Financial = BuildFinancial(creditReport),
            };

            return result;
        }

        /// <summary>
        /// Creates a <see cref="General"/> object from a <see cref="CreditReport"/>.
        /// </summary>
        /// <param name="creditReport"><see cref="CreditReport"/> object from which to create a <see cref="General"/> object.</param>
        /// <returns><see cref="General"/> object.</returns>
        private static General BuildGeneral(CreditReport creditReport)
        {
            General general = new General
            {
                Language = creditReport.Report.Language,
                VisitingAddress = creditReport.Report.ContactInformation.MainAddress,
                PostalAddress = creditReport.Report.ContactInformation.OtherAddresses
                    .FirstOrDefault(address => Regex.IsMatch(address.Type, @"postal", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)),
                PhoneNumber = creditReport.Report.ContactInformation.MainAddress.Telephone,
            };

            if (creditReport.Report.ContactInformation.Websites.Any(website =>
                    Regex.IsMatch(website, @"\.nl", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)))
            {
                general.Website = creditReport.Report.ContactInformation.Websites.FirstOrDefault(website =>
                    Regex.IsMatch(website, @"\.nl", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));
            }
            else
            {
                general.Website = creditReport.Report.ContactInformation.Websites.FirstOrDefault();
            }

            return general;
        }

        /// <summary>
        /// Creates a <see cref="Financial"/> object from a <see cref="CreditReport"/>.
        /// </summary>
        /// <param name="creditReport"><see cref="CreditReport"/> object from which to create a <see cref="Financial"/> object.</param>
        /// <returns><see cref="Financial"/> object.</returns>
        private static Financial BuildFinancial(CreditReport creditReport)
        {
            Financial financial = new Financial
            {
                RegistrationNumber = creditReport.Report.CompanySummary.CompanyRegistrationNumber,
                RegistrationDate = creditReport.Report.CompanyIdentification.BasicInformation.CompanyRegistrationDate,
                CreditLimit = decimal.Parse(creditReport.Report.CompanySummary.CreditRating.CreditLimit.Value),
                CreditScore = creditReport.Report.CompanySummary.CreditRating.CommonValue,
                Currency = creditReport.Report.CompanySummary.CreditRating.CreditLimit.Currency,
            };

            // EORI Number = Country code + RSIN (if length < 9, keep APPENDING 0)
            string rsin = creditReport.Report.AdditionalInformation.Misc.RsinNumber;
            financial.EoriNumber = creditReport.Report.CompanySummary.Country + new string('0', 9 - rsin.Length > 0 ? 9 - rsin.Length : 0) + rsin;

            financial.UltimateParent = creditReport.Report.GroupStructure.UltimateParent;
            financial.ImmediateParent = creditReport.Report.GroupStructure.ImmediateParent;
            financial.Employees = int.Parse(creditReport.Report.OtherInformation.EmployeesInformation
                .OrderByDescending(employeeInformation => employeeInformation.Year).FirstOrDefault()
                ?.NumberOfEmployees ?? string.Empty);
            financial.LegalForm = creditReport.Report.CompanyIdentification.BasicInformation.LegalForm;

            return financial;
        }
    }
}
