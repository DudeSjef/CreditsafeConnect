// <copyright file="IAuthenticationHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;

    /// <summary>
    /// Class for handling authentication HTTP request.
    /// </summary>
    internal interface IAuthenticationHttpClient
    {
        /// <summary>
        /// Sends an authentication request.
        /// </summary>
        /// <param name="authenticationRequest">Request object with authentication endpoint and login credentials.</param>
        /// <returns><see cref="AuthenticationToken"/>.</returns>
        Task<AuthenticationToken> Authenticate(Request authenticationRequest);
    }
}
