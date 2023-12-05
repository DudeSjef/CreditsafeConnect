// <copyright file="AuthenticationService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    /// <inheritdoc cref="IAuthenticationService"/>
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository authenticationRepository = new AuthenticationRepository();

        /// <summary>
        /// Calls the Authenticate method in the repository layer.
        /// </summary>
        /// <param name="endpoint">URI of the authenticate endpoint.</param>
        /// <param name="username">Username for authenticating to the authentication endpoint.</param>
        /// <param name="password">Password for authenticating to the authentication endpoint.</param>
        /// <returns>An asynchronous operation.</returns>
        public async Task<AuthenticationToken> Authenticate(string endpoint, string username, string password)
        {
            object login = new
            {
                username,
                password,
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request authenticationRequest = requestBuilder
                .Endpoint(endpoint)
                .Payload(login)
                .Build();

            return await this.authenticationRepository.Authenticate(authenticationRequest);
        }
    }
}
