// <copyright file="IPortfolioService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.PortfolioModels;

    /// <summary>
    /// Service class for handling portfolio requests.
    /// </summary>
    internal interface IPortfolioService
    {
        /// <summary>
        /// Calls the GetPortfoliosByName method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolios endpoint.</param>
        /// <param name="name">Name of the portfolio to search for.</param>
        /// <returns><see cref="List{Portfolio}"/>.</returns>
        Task<List<Portfolio>> GetPortfoliosByName(string authenticationToken, string endpoint, string name);

        /// <summary>
        /// Calls the CreatePortfolio method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolios endpoint.</param>
        /// <param name="name">Name of the portfolio.</param>
        /// <returns>An asynchronous operation.</returns>
        Task CreatePortfolio(string authenticationToken, string endpoint, string name);

        /// <summary>
        /// Calls the AddCompanyToPortfolio method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolios endpoint.</param>
        /// <param name="portfolioId">Id of the portfolio to add the company to.</param>
        /// <param name="companyId">Id of the company to add to the portfolio.</param>
        /// <returns>An asynchronous operation.</returns>
        Task AddCompanyToPortfolio(string authenticationToken, string endpoint, string portfolioId, string companyId);

        /// <summary>
        /// Calls the RemoveCompanyFromPortfolio method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolios endpoint.</param>
        /// <param name="portfolioId">Id of the portfolio to remove the company from.</param>
        /// <param name="companyId">Id of the company to remove from the portfolio.</param>
        /// <returns>An asynchronous operation.</returns>
        Task RemoveCompanyFromPortfolio(string authenticationToken, string endpoint, string portfolioId, string companyId);
    }
}
