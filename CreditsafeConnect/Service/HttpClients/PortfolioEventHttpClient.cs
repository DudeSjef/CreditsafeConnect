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

    internal class PortfolioEventHttpClient : IPortfolioEventHttpClient
    {
        private readonly HttpClient httpClient;

        internal PortfolioEventHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getAllPortfolioEventsRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getAllPortfolioEventsRequest.EndpointUri + getAllPortfolioEventsRequest.PathParameters);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<PortfolioEvent>>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
