// <copyright file="CreditReportController.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.CreditReportModels;
    using CreditsafeConnect.Service;
    using CreditsafeConnect.Service.Interfaces;

    /// <summary>
    /// Application entry point for getting extended company information.<br/><br/>
    /// See <seealso cref="CompanyController"/> for brief company information.
    /// </summary>
    public class CreditReportController
    {
        private readonly ICreditReportService creditReportService = new CreditReportService();

        /// <summary>
        /// Gets a credit report for a company based on the given company ID.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the credit report endpoint.</param>
        /// <param name="companyId">ID of the company as a string.</param>
        /// <param name="language">Two-letter country code (ISO 3166-1 alpha-2) which determines the language of the returned credit report.</param>
        /// <returns>CreditReport object.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the parameters has an illegal value.
        /// </exception>
        public async Task<CreditReportResult> GetCreditReport(string authenticationToken, string endpoint, string companyId, string language = "nl")
        {
            if (string.IsNullOrWhiteSpace(authenticationToken)) throw new ArgumentException("Authentication token cannot be empty.");
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");
            if (string.IsNullOrWhiteSpace(companyId)) throw new ArgumentException("Company ID cannot be empty.");

            return await this.creditReportService.GetCreditReport(authenticationToken, endpoint, companyId, language);
        }
    }
}
