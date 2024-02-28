// <copyright file="AuthenticationController.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Service;
    using CreditsafeConnect.Service.Interfaces;

    /// <summary>
    /// Application entry point for authentication.
    /// </summary>
    public class AuthenticationController
    {
        private readonly IAuthenticationService authenticationService = new AuthenticationService();

        /// <summary>
        /// Calls the <see cref="AuthenticationService.Authenticate"/> method in the <see cref="AuthenticationService"/>.
        /// </summary>
        /// <param name="endpoint">URI of the authenticate endpoint.</param>
        /// <returns>An asynchronous operation.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the arguments is empty.
        /// </exception>
        public async Task<AuthenticationToken> Authenticate(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");

            return await this.authenticationService.Authenticate(endpoint);
        }
    }
}
