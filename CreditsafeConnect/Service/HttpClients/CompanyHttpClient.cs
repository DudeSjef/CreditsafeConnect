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
    using Newtonsoft.Json;

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

        /// <summary>
        /// Retrieves company information based on the request parameter in the <paramref name="getCompaniesRequest"/>.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with company search criteria in the request parameter.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the http response status code is not successful.
        /// </exception>
        /// <exception cref="UriFormatException">
        /// Thrown when the base address URI format is invalid.
        /// </exception>
        public async Task<List<Company>> GetCompanies(Request getCompaniesRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getCompaniesRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getCompaniesRequest.EndpointUri + getCompaniesRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            CompanyList companyList = JsonConvert.DeserializeObject<CompanyList>(response.Content.ReadAsStringAsync().Result);

            return companyList.Companies;
        }
    }
}
