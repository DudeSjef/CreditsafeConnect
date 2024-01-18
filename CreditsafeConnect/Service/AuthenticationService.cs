// <copyright file="AuthenticationService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Properties;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    /// <inheritdoc cref="IAuthenticationService"/>
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository authenticationRepository = new AuthenticationRepository();

        /// <inheritdoc cref="IAuthenticationService.Authenticate"/>
        public async Task<AuthenticationToken> Authenticate(string endpoint)
        {
            object login = new
            {
                // Resources.Username,
                // Resources.Password,
                username = "Multitube",
                password = "Multitube01",
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
