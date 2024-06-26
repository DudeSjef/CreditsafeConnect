﻿// <copyright file="PortfolioHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc cref="IPortfolioHttpClient"/>
    public class PortfolioHttpClient : IPortfolioHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> to be used for sending HTTP requests.</param>
        public PortfolioHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        /// <inheritdoc cref="IPortfolioHttpClient.GetPortfoliosByName"/>
        public async Task<IEnumerable<Portfolio>> GetPortfoliosByName(Request getPortfoliosByNameRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getPortfoliosByNameRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getPortfoliosByNameRequest.EndpointUri + getPortfoliosByNameRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            JToken data = jsonObject.SelectToken("data");

            JToken portfolios = data?.SelectToken("portfolios");

            return portfolios?.ToObject<List<Portfolio>>().AsEnumerable();
        }

        /// <inheritdoc cref="IPortfolioHttpClient.CreatePortfolio"/>
        public async Task CreatePortfolio(Request createPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = createPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PostAsync(createPortfolioRequest.EndpointUri, createPortfolioRequest.Payload);

            // HTTP response code 409 means portfolio already exists with the given name
            if (response.StatusCode == HttpStatusCode.Conflict) return;
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc cref="IPortfolioHttpClient.AddCompanyToPortfolio"/>
        public async Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = addCompanyToPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PostAsync(addCompanyToPortfolioRequest.EndpointUri + addCompanyToPortfolioRequest.PathParameters, addCompanyToPortfolioRequest.Payload);

            // HTTP response code 409 means company has already been added to portfolio
            if (response.StatusCode == HttpStatusCode.Conflict) return;
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc cref="IPortfolioHttpClient.RemoveCompanyFromPortfolio"/>
        public async Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = removeCompanyFromPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.DeleteAsync(removeCompanyFromPortfolioRequest.EndpointUri +
                    removeCompanyFromPortfolioRequest.PathParameters);

            // HTTP response code 404 means company is not in portfolio
            if (response.StatusCode == HttpStatusCode.NotFound) return;
            response.EnsureSuccessStatusCode();
        }
    }
}
