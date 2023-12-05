// <copyright file="CreditsafeHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Service.Interfaces;
    using Newtonsoft.Json;

    /// <inheritdoc cref="ICreditsafeHttpClient"/>
    internal class CreditsafeHttpClient : ICreditsafeHttpClient
    {
        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditsafeHttpClient"/> class and sets the base address of the <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="client"><see cref="HttpClient"/> to be used in a singleton-like instance.</param>
        public CreditsafeHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri(Resource.SandboxUrl);

            this.client = client;
        }

        /// <summary>
        /// Uses the <paramref name="authenticationRequest"/> to authenticate to the Creditsafe API and returns the authentication token.
        /// </summary>
        /// <param name="authenticationRequest">Request object with authentication endpoint and login credentials.</param>
        /// <returns>An <see cref="AuthenticationToken"/>.</returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the http response status code is not successful.
        /// </exception>
        /// <exception cref="UriFormatException">
        /// Thrown when the base address URI format is invalid.
        /// </exception>
        public async Task<AuthenticationToken> Authenticate(Request authenticationRequest)
        {
            HttpResponseMessage response =
                await this.client.PostAsync(authenticationRequest.EndpointUri, authenticationRequest.Payload);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<AuthenticationToken>(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Retrieves brief company information based on the request parameter in the <paramref name="getCompaniesRequest"/>.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with company search criteria in the request parameter.</param>
        /// <returns>IEnumerable of <see cref="Company"/> or an empty enumerable.</returns>
        /// <exception cref="HttpRequestException">
        /// Thrown when the http response status code is not successful.
        /// </exception>
        /// <exception cref="UriFormatException">
        /// Thrown when the base address URI format is invalid.
        /// </exception>
        public async Task<IEnumerable<Company>> GetCompanies(Request getCompaniesRequest)
        {
            this.client.DefaultRequestHeaders.Authorization = getCompaniesRequest.AuthenticationToken;

            HttpResponseMessage response =
                await this.client.GetAsync(getCompaniesRequest.EndpointUri + getCompaniesRequest.RequestParameters);

            response.EnsureSuccessStatusCode();

            CompanyList companyList = JsonConvert.DeserializeObject<CompanyList>(response.Content.ReadAsStringAsync().Result);

            return companyList.Companies;
        }
    }
}
