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

        /// <inheritdoc cref="IAuthenticationRepository.Authenticate"/>
        public async Task<AuthenticationToken> Authenticate(Request authenticationRequest)
        {
            return await this.authenticationHttpClient.Authenticate(authenticationRequest);
        }
    }
}
