// <copyright file="IAuthenticationService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.Interfaces
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;

    /// <summary>
    /// Service class for handling authentication requests.
    /// </summary>
    internal interface IAuthenticationService
    {
        /// <summary>
        /// Calls the Authenticate method in the repository layer and returns an authentication token.
        /// </summary>
        /// <param name="endpoint">URI of the authenticate endpoint.</param>
        /// <param name="username">Username of the API account.</param>
        /// <param name="password">Password of the API account.</param>
        /// <returns>An authentication token.</returns>
        Task<AuthenticationToken> Authenticate(string endpoint, string username, string password);
    }
}
