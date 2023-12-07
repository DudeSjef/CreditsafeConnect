// <copyright file="ICreditsafeHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;

    /// <summary>
    /// Class that creates and handles HTTP requests.
    /// </summary>
    internal interface ICreditsafeHttpClient
    {
        /// <summary>
        /// Uses the <paramref name="authenticationRequest"/> to authenticate to the Creditsafe API and returns the authentication token.
        /// </summary>
        /// <param name="authenticationRequest">Request object with authentication endpoint and login credentials.</param>
        /// <returns>An <see cref="AuthenticationToken"/>.</returns>
        Task<AuthenticationToken> Authenticate(Request authenticationRequest);

        /// <summary>
        /// Retrieves brief company information based on the request parameter in the <paramref name="getCompaniesRequest"/>.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with company search criteria in the request parameter.</param>
        /// <returns>IEnumerable of <see cref="Company"/> or an empty enumerable.</returns>
        Task<IEnumerable<Company>> GetCompanies(Request getCompaniesRequest);
    }
}
