// <copyright file="CreditReportService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CreditReportModels;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    /// <summary>
    /// <inheritdoc cref="ICreditReportService"/>
    /// </summary>
    internal class CreditReportService : ICreditReportService
    {
        private readonly ICreditReportRepository creditReportRepository = new CreditReportRepository();

        /// <inheritdoc cref="ICreditReportService.GetCreditReport"/>
        public async Task<CreditReportResult> GetCreditReport(string authenticationToken, string endpoint, string companyId, string language)
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>()
            {
                { "language", language }
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request getCreditReportRequest = requestBuilder
                .Endpoint(endpoint)
                .PathParameters(companyId)
                .RequestParameters(requestParameters)
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.creditReportRepository.GetCreditReport(getCreditReportRequest);
        }
    }
}
