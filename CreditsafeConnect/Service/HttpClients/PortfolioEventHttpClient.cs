// <copyright file="PortfolioEventHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc cref="IPortfolioEventHttpClient"/>
    internal class PortfolioEventHttpClient : IPortfolioEventHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioEventHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> to be used for sending HTTP requests.</param>
        internal PortfolioEventHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        /// <inheritdoc cref="IPortfolioEventHttpClient.GetAllPortfolioEvents"/>
        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getAllPortfolioEventsRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getAllPortfolioEventsRequest.EndpointUri + getAllPortfolioEventsRequest.PathParameters + getAllPortfolioEventsRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            JToken portfolioEvents = jsonObject.SelectToken("data");

            return portfolioEvents?.ToObject<List<PortfolioEvent>>();
        }

        /// <inheritdoc cref="IPortfolioEventHttpClient.GetPortfolioEventsCount"/>.
        public async Task<int> GetPortfolioEventsCount(Request getPortfolioEventsCountRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getPortfolioEventsCountRequest.AuthenticationHeader;

            HttpResponseMessage response = await this.httpClient.GetAsync(getPortfolioEventsCountRequest.EndpointUri + getPortfolioEventsCountRequest.PathParameters + getPortfolioEventsCountRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            JObject jsonJObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return int.TryParse(jsonJObject.SelectToken("totalCount")?.Value<string>(), out int eventsCount) ? eventsCount : 0;
        }

        /// <inheritdoc cref="IPortfolioEventHttpClient.UpdateEventRules"/>
        public async Task UpdateEventRules(Request updateEventRulesRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = updateEventRulesRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PutAsync(
                    updateEventRulesRequest.EndpointUri + updateEventRulesRequest.PathParameters,
                    updateEventRulesRequest.Payload);

            response.EnsureSuccessStatusCode();
        }
    }
}
