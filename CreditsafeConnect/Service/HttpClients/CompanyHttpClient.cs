// <copyright file="CompanyHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CompanyModels;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc cref="ICompanyHttpClient"/>
    internal class CompanyHttpClient : ICompanyHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> to be used for sending HTTP requests.</param>
        internal CompanyHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        /// <inheritdoc cref="ICompanyHttpClient.GetCompanies"/>
        public async Task<List<Company>> GetCompanies(Request getCompaniesRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getCompaniesRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getCompaniesRequest.EndpointUri + getCompaniesRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            JObject jsonObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            JToken companies = jsonObject.SelectToken("companies");

            return companies?.ToObject<List<Company>>();
        }
    }
}
