// <copyright file="CreditReportHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CreditReportModels;
    using CreditsafeConnect.Models.CreditReportModels.Internal;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json.Linq;

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

        /// <inheritdoc cref="ICreditReportHttpClient.GetCreditReport"/>
        public async Task<CreditReportResult> GetCreditReport(Request getCreditReportRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getCreditReportRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getCreditReportRequest.EndpointUri + getCreditReportRequest.PathParameters + getCreditReportRequest.RequestParameters);

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new AuthorizationException();
            }

            response.EnsureSuccessStatusCode();

            JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            JToken creditReport = jsonObject.SelectToken("report");

            Report report = creditReport?.ToObject<Report>();

            CreditReportBuilder creditReportBuilder = new CreditReportBuilder();

            return creditReportBuilder.BuildCreditReport(report);
        }
    }
}