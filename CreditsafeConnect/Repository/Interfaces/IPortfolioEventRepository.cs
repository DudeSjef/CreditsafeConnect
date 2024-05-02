// <copyright file="IPortfolioEventRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;

    /// <summary>
    /// Data access class for portfolio events.
    /// </summary>
    internal interface IPortfolioEventRepository
    {
        /// <summary>
        /// Calls the <see cref="Service.HttpClients.PortfolioEventHttpClient.GetAllPortfolioEvents"/> method in the <see cref="Service.HttpClients.PortfolioEventHttpClient"/>.
        /// </summary>
        /// <param name="getAllPortfolioEventsRequest">Request object with portfolio events endpoint.</param>
        /// <returns><see cref="List{PortfolioEvent}"/>.</returns>
        Task<IEnumerable<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest);

        /// <summary>
        /// Retrieves the number of portfolio events.
        /// </summary>
        /// <param name="getPortfolioEventsCountRequest">Request object with portfolio event endpoint and portfolio ID.</param>
        /// <returns>Number of portfolio events.</returns>
        Task<int> GetPortfolioEventsCount(Request getPortfolioEventsCountRequest);

        /// <summary>
        /// Calls the <see cref="Service.HttpClients.PortfolioEventHttpClient.UpdateEventRules"/> method in the <see cref="Service.HttpClients.PortfolioEventHttpClient"/>.
        /// </summary>
        /// <param name="updateEventRulesRequest">Request object with portfolio ID, country code, and event rule settings.</param>
        /// <returns>An asynchronous operation.</returns>
        Task UpdateEventRules(Request updateEventRulesRequest);
    }
}
