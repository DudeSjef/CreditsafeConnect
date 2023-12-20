// <copyright file="ICreditReportRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CreditReportModels;

    /// <summary>
    /// Data access class for extended company information.<br/><br/>
    /// See <seealso cref="ICompanyRepository"/> for brief company information.
    /// </summary>
    internal interface ICreditReportRepository
    {
        /// <summary>
        /// Calls the <see cref="Service.HttpClients.CreditReportHttpClient.GetCreditReport"/> method in the <see cref="Service.HttpClients.CreditReportHttpClient"/>.
        /// </summary>
        /// <param name="getCreditReportRequest">Request object with company id in the path parameter.</param>
        /// <returns>CreditReport object.</returns>
        Task<CreditReportResult> GetCreditReport(Request getCreditReportRequest);
    }
}
