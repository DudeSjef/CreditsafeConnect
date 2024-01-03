// <copyright file="AuthenticationHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Service.HttpClients.Interfaces;
    using Newtonsoft.Json;

    /// <inheritdoc cref="IAuthenticationHttpClient"/>
    internal class AuthenticationHttpClient : IAuthenticationHttpClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationHttpClient"/> class and sets the base address of the <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> to be used for sending HTTP requests.</param>
        internal AuthenticationHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        /// <inheritdoc cref="IAuthenticationHttpClient.Authenticate"/>
        public async Task<AuthenticationToken> Authenticate(Request authenticationRequest)
        {
            HttpResponseMessage response =
                await this.httpClient.PostAsync(authenticationRequest.EndpointUri, authenticationRequest.Payload);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<AuthenticationToken>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
