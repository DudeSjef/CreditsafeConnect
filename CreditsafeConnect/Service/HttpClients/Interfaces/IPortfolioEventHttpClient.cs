// <copyright file="IPortfolioEventHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;

    /// <summary>
    /// Class for handling portfolio event HTTP requests.
    /// </summary>
    internal interface IPortfolioEventHttpClient
    {
        /// <summary>
        /// Retrieves all portfolio events.
        /// </summary>
        /// <param name="getAllPortfolioEventsRequest">Request object with portfolio event endpoint and portfolio ID.</param>
        /// <returns><see cref="List{PortfolioEvent}"/>.</returns>
        Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest);

        /// <summary>
        /// Updates portfolio event rule settings.
        /// </summary>
        /// <param name="updateEventRulesRequest">Request object with portfolio event endpoint and event rule settings.</param>
        /// <returns>An asynchronous operation.</returns>
        Task UpdateEventRules(Request updateEventRulesRequest);
    }
}
