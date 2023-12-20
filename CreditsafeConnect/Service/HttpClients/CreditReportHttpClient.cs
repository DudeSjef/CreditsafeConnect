// <copyright file="CreditReportHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CreditReportModels;
    using CreditsafeConnect.Models.CreditReportModels.Internal;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json;

    /// <inheritdoc cref="ICreditReportHttpClient"/>
    internal class CreditReportHttpClient : ICreditReportHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditReportHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> to be used for sending HTTP requests.</param>
        internal CreditReportHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves credit report with extended company information based on the path parameter in the <paramref name="getCreditReportRequest"/>.
        /// </summary>
        /// <param name="getCreditReportRequest">Request object with credit report endpoint and companyId in the path parameter.</param>
        /// <returns><see cref="CreditReport"/>.</returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the http response status code is not successful.
        /// </exception>
        /// <exception cref="UriFormatException">
        /// Thrown when the base address URI format is invalid.
        /// </exception>
        public async Task<CreditReportResult> GetCreditReport(Request getCreditReportRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getCreditReportRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getCreditReportRequest.EndpointUri + getCreditReportRequest.PathParameters);

            response.EnsureSuccessStatusCode();

            CreditReport creditReport = JsonConvert.DeserializeObject<CreditReport>(response.Content.ReadAsStringAsync().Result);

            CreditReportBuilder creditReportBuilder = new CreditReportBuilder();

            return creditReportBuilder.BuildCreditReport(creditReport);
        }
    }
}