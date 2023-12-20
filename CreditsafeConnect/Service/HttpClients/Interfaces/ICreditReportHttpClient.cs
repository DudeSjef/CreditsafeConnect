// <copyright file="ICreditReportHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CreditReportModels;

    /// <summary>
    /// Class for handling credit report HTTP requests.
    /// </summary>
    internal interface ICreditReportHttpClient
    {
        /// <summary>
        /// Retrieves a credit report.
        /// </summary>
        /// <param name="getCreditReportRequest">Request object with credit report endpoint and companyId in the path parameter.</param>
        /// <returns><see cref="CreditReportResult"/>.</returns>
        Task<CreditReportResult> GetCreditReport(Request getCreditReportRequest);
    }
}
