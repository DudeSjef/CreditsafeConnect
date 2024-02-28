// <copyright file="IPortfolioHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioModels;

    /// <summary>
    /// Class for handling portfolio HTTP requests.
    /// </summary>
    public interface IPortfolioHttpClient
    {
        /// <summary>
        /// Retrieves all portfolios by name.
        /// </summary>
        /// <param name="getPortfoliosByNameRequest">Request object with portfolios endpoint and portfolio name.</param>
        /// <returns><see cref="List{Portfolio}"/>.</returns>
        Task<IEnumerable<Portfolio>> GetPortfoliosByName(Request getPortfoliosByNameRequest);

        /// <summary>
        /// Creates a portfolio.
        /// </summary>
        /// <param name="createPortfolioRequest">Request object with portfolios endpoint and portfolio name.</param>
        /// <returns>An asynchronous operation.</returns>
        Task CreatePortfolio(Request createPortfolioRequest);

        /// <summary>
        /// Adds a company to a portfolio.
        /// </summary>
        /// <param name="addCompanyToPortfolioRequest">Request object with portfolios endpoint, portfolio ID, and company ID.</param>
        /// <returns>An asynchronous operation.</returns>
        Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest);

        /// <summary>
        /// Removes a company from a portfolio.
        /// </summary>
        /// <param name="removeCompanyFromPortfolioRequest">Request object with portfolios endpoint, portfolio ID, and company ID.</param>
        /// <returns>An asynchronous operation.</returns>
        Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest);
    }
}
