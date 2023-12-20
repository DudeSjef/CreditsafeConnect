// <copyright file="AuthenticationRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.HttpClients;
    using CreditsafeConnect.Service.HttpClients.Interfaces;

    /// <inheritdoc cref="IAuthenticationRepository"/>
    internal class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IAuthenticationHttpClient authenticationHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationRepository"/> class.
        /// </summary>
        internal AuthenticationRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.authenticationHttpClient = new AuthenticationHttpClient(httpClient);
        }

        /// <summary>
        /// Calls the <see cref="AuthenticationHttpClient.Authenticate"/> method in the <see cref="AuthenticationHttpClient"/>.
        /// </summary>
        /// <param name="authenticationRequest">Request object containing all the information necessary to send an authentication request.</param>
        /// <returns>An asynchronous operation.</returns>
        public async Task<AuthenticationToken> Authenticate(Request authenticationRequest)
        {
            return await this.authenticationHttpClient.Authenticate(authenticationRequest);
        }
    }
}
