// <copyright file="PortfolioRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.HttpClients;
    using CreditsafeConnect.Service.HttpClients.Interfaces;

    /// <inheritdoc cref="IPortfolioRepository"/>
    internal class PortfolioRepository : IPortfolioRepository
    {
        private readonly IPortfolioHttpClient portfolioHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioRepository"/> class.
        /// </summary>
        internal PortfolioRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.portfolioHttpClient = new PortfolioHttpClient(httpClient);
        }

        /// <inheritdoc cref="IPortfolioRepository.GetPortfoliosByName"/>
        public async Task<IEnumerable<Portfolio>> GetPortfoliosByName(Request getPortfoliosByNameRequest)
        {
            return await this.portfolioHttpClient.GetPortfoliosByName(getPortfoliosByNameRequest);
        }

        /// <inheritdoc cref="IPortfolioRepository.CreatePortfolio"/>
        public async Task CreatePortfolio(Request createPortfolioRequest)
        {
            await this.portfolioHttpClient.CreatePortfolio(createPortfolioRequest);
        }

        /// <inheritdoc cref="IPortfolioRepository.AddCompanyToPortfolio"/>
        public async Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest)
        {
            await this.portfolioHttpClient.AddCompanyToPortfolio(addCompanyToPortfolioRequest);
        }

        /// <inheritdoc cref="IPortfolioRepository.RemoveCompanyFromPortfolio"/>
        public async Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest)
        {
            await this.portfolioHttpClient.RemoveCompanyFromPortfolio(removeCompanyFromPortfolioRequest);
        }
    }
}
