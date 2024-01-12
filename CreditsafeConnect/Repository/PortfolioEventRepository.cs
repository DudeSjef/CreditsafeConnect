// <copyright file="PortfolioEventRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.HttpClients;
    using CreditsafeConnect.Service.HttpClients.Interfaces;

    /// <inheritdoc cref="IPortfolioEventRepository"/>
    internal class PortfolioEventRepository : IPortfolioEventRepository
    {
        private readonly IPortfolioEventHttpClient portfolioEventHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioEventRepository"/> class.
        /// </summary>
        internal PortfolioEventRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.portfolioEventHttpClient = new PortfolioEventHttpClient(httpClient);
        }

        /// <inheritdoc cref="IPortfolioEventRepository.GetAllPortfolioEvents"/>
        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest)
        {
            return await this.portfolioEventHttpClient.GetAllPortfolioEvents(getAllPortfolioEventsRequest);
        }

        /// <inheritdoc cref="IPortfolioEventRepository.GetPortfolioEventsCount"/>
        public async Task<int> GetPortfolioEventsCount(Request getPortfolioEventsCountRequest)
        {
            return await this.portfolioEventHttpClient.GetPortfolioEventsCount(getPortfolioEventsCountRequest);
        }

        /// <inheritdoc cref="IPortfolioEventRepository.UpdateEventRules"/>
        public async Task UpdateEventRules(Request updateEventRulesRequest)
        {
            await this.portfolioEventHttpClient.UpdateEventRules(updateEventRulesRequest);
        }
    }
}
