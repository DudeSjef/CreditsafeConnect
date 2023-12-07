// <copyright file="IAuthenticationRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;

    /// <summary>
    /// Data access class for authentication.
    /// </summary>
    internal interface IAuthenticationRepository
    {
        /// <summary>
        /// Calls the <see cref="Service.CreditsafeHttpClient.Authenticate"/> method in the <see cref="Service.CreditsafeHttpClient"/>.
        /// </summary>
        /// <param name="authenticationRequest">Request object with authentication endpoint and login credentials.</param>
        /// <returns>An asynchronous operation.</returns>
        Task<AuthenticationToken> Authenticate(Request authenticationRequest);
    }
}
