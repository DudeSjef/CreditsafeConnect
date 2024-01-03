// <copyright file="IPortfolioRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioModels;

    /// <summary>
    /// Data access class for portfolios.
    /// </summary>
    internal interface IPortfolioRepository
    {
        /// <summary>
        /// Calls the <see cref="Service.HttpClients.PortfolioHttpClient.GetPortfoliosByName"/> method in the <see cref="Service.HttpClients.PortfolioHttpClient"/>.
        /// </summary>
        /// <param name="getPortfoliosByNameRequest">Request object with portfolios endpoint, and portfolio name to search for.</param>
        /// <returns><see cref="List{Portfolio}"/>.</returns>
        Task<List<Portfolio>> GetPortfoliosByName(Request getPortfoliosByNameRequest);

        /// <summary>
        /// Calls the <see cref="Service.HttpClients.PortfolioHttpClient.CreatePortfolio"/> method in the <see cref="Service.HttpClients.PortfolioHttpClient"/>.
        /// </summary>
        /// <param name="createPortfolioRequest">Request object with portfolios endpoint, and portfolio name.</param>
        /// <returns>An asynchronous operation.</returns>
        Task CreatePortfolio(Request createPortfolioRequest);

        /// <summary>
        /// Calls the <see cref="Service.HttpClients.PortfolioHttpClient.AddCompanyToPortfolio"/> method in the <see cref="Service.HttpClients.PortfolioHttpClient"/>.
        /// </summary>
        /// <param name="addCompanyToPortfolioRequest">Request object with portfolio ID, and company ID.</param>
        /// <returns>An asynchronous operation.</returns>
        Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest);

        /// <summary>
        /// Calls the <see cref="Service.HttpClients.PortfolioHttpClient.RemoveCompanyFromPortfolio"/> method in the <see cref="Service.HttpClients.PortfolioHttpClient"/>.
        /// </summary>
        /// <param name="removeCompanyFromPortfolioRequest">Request object with portfolio ID, and company ID.</param>
        /// <returns>An asynchronous operation.</returns>
        Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest);
    }
}
