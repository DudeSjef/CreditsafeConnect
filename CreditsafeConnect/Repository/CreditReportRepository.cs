﻿// <copyright file="CreditReportRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CreditReportModels;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.HttpClients;
    using CreditsafeConnect.Service.HttpClients.Interfaces;

    /// <inheritdoc cref="ICreditReportRepository"/>
    internal class CreditReportRepository : ICreditReportRepository
    {
        private readonly ICreditReportHttpClient creditReportHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditReportRepository"/> class.
        /// </summary>
        internal CreditReportRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.creditReportHttpClient = new CreditReportHttpClient(httpClient);
        }

        /// <inheritdoc cref="ICreditReportRepository.GetCreditReport"/>
        public async Task<CreditReportResult> GetCreditReport(Request getCreditReportRequest)
        {
            return await this.creditReportHttpClient.GetCreditReport(getCreditReportRequest);
        }
    }
}
