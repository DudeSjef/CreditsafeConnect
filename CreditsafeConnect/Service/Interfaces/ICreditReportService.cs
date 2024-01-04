// <copyright file="ICreditReportService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.Interfaces
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.CreditReportModels;

    /// <summary>
    /// Service class for handling credit report requests.
    /// </summary>
    internal interface ICreditReportService
    {
        /// <summary>
        /// Calls the GetCreditReport method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the credit report endpoint.</param>
        /// <param name="companyId">Company ID as a string to be sent in the path parameter.</param>
        /// <param name="language">Two-letter country code (ISO 3166-1 alpha-2) which determines the language of the returned credit report.</param>
        /// <returns><see cref="CreditReportResult"/>.</returns>
        Task<CreditReportResult> GetCreditReport(string authenticationToken, string endpoint, string companyId, string language);
    }
}
