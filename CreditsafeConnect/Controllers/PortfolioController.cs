// <copyright file="PortfolioController.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Service;
    using CreditsafeConnect.Service.Interfaces;

    /// <summary>
    /// Application entry point for handling <see cref="Portfolio"/> requests.
    /// </summary>
    public class PortfolioController
    {
        private readonly IPortfolioService portfolioService = new PortfolioService();

        /// <summary>
        /// Gets a list of portfolios based on the given name.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolios endpoint.</param>
        /// <param name="name">Name of the portfolio to search for.</param>
        /// <returns>List of <see cref="Portfolio"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the parameters has an illegal value.
        /// </exception>
        public async Task<IEnumerable<Portfolio>> GetPortfolios(string authenticationToken, string endpoint, string name)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken)) throw new ArgumentException("Authentication token cannot be empty.");
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");

            return await this.portfolioService.GetPortfoliosByName(authenticationToken, endpoint, name);
        }

        public async Task CreatePortfolio(string authenticationToken, string endpoint, string name)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken)) throw new ArgumentException("Authentication token cannot be empty.");
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");

            await this.portfolioService.CreatePortfolio(authenticationToken, endpoint, name);
        }
    }
}
