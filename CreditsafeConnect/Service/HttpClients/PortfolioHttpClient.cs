﻿// <copyright file="PortfolioHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc cref="IPortfolioHttpClient"/>
    internal class PortfolioHttpClient : IPortfolioHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> to be used for sending HTTP requests.</param>
        internal PortfolioHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        /// <inheritdoc cref="IPortfolioHttpClient.GetPortfoliosByName"/>
        public async Task<List<Portfolio>> GetPortfoliosByName(Request getPortfoliosByNameRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getPortfoliosByNameRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getPortfoliosByNameRequest.EndpointUri + getPortfoliosByNameRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            JToken data = jsonObject.SelectToken("data");

            JToken portfolios = data?.SelectToken("portfolios");

            return portfolios?.ToObject<List<Portfolio>>();
        }

        /// <inheritdoc cref="IPortfolioHttpClient.CreatePortfolio"/>
        public async Task CreatePortfolio(Request createPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = createPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PostAsync(createPortfolioRequest.EndpointUri, createPortfolioRequest.Payload);

            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc cref="IPortfolioHttpClient.AddCompanyToPortfolio"/>
        public async Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = addCompanyToPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PostAsync(addCompanyToPortfolioRequest.EndpointUri, addCompanyToPortfolioRequest.Payload);

            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc cref="IPortfolioHttpClient.RemoveCompanyFromPortfolio"/>
        public async Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = removeCompanyFromPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.DeleteAsync(removeCompanyFromPortfolioRequest.EndpointUri +
                    removeCompanyFromPortfolioRequest.PathParameters);

            response.EnsureSuccessStatusCode();
        }
    }
}