// <copyright file="IPortfolioEventService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.PortfolioEventModels;

    /// <summary>
    /// Service class for handling portfolio event requests.
    /// </summary>
    internal interface IPortfolioEventService
    {
        /// <summary>
        /// Calls the GetAllPortfolioEvents method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolio events endpoint.</param>
        /// <param name="portfolioId">ID of the portfolio to retrieve the events from.</param>
        /// <param name="sortBy">Field to sort the results by. Default is eventDate.</param>
        /// <param name="sortDir">Direction to sort the results in. Default is descending.</param>
        /// <param name="startDate">Date to start retrieving events from.</param>
        /// <returns><see cref="List{PortfolioEvent}"/>.</returns>
        Task<List<PortfolioEvent>> GetAllPortfolioEvents(string authenticationToken, string endpoint, string portfolioId, string sortBy, string sortDir, string startDate);

        /// <summary>
        /// Calls the UpdateEventRules method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolio event rules endpoint.</param>
        /// <param name="portfolioId">ID of the portfolio to update the event rules in.</param>
        /// <param name="countryCode">Two-letter country code (ISO 3166-1 alpha-2) for updating country-specific settings.</param>
        /// <param name="eventRuleSettings"><see cref="IEnumerable{EventRuleSetting}"/> with objects that contain the event rule settings.</param>
        /// <returns>An asynchronous operation.</returns>
        Task UpdateEventRules(string authenticationToken, string endpoint, string portfolioId, string countryCode, IEnumerable<EventRuleSetting> eventRuleSettings);
    }
}
