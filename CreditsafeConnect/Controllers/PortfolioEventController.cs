// <copyright file="PortfolioEventController.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Service;
    using CreditsafeConnect.Service.Interfaces;

    /// <summary>
    /// Application entry point for handling <see cref="PortfolioEvent"/> requests.
    /// </summary>
    public class PortfolioEventController
    {
        private readonly IPortfolioEventService portfolioEventService = new PortfolioEventService();

        /// <summary>
        /// Gets a list of all portfolio events.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolio events endpoint.</param>
        /// <param name="portfolioId">ID of the portfolio to retrieve the events from.</param>
        /// <param name="startDate">Date to start retrieving events from.</param>
        /// <param name="sortBy">Field to sort the results by. Default is eventDate.</param>
        /// <param name="sortDir">Direction to sort the results in. Default is descending.</param>
        /// <returns><see cref="List{PortfolioEvent}"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the parameters has an illegal value.
        /// </exception>
        public async Task<IEnumerable<PortfolioEvent>> GetAllPortfolioEvents(string authenticationToken, string endpoint, string portfolioId, string startDate, string sortBy = "eventDate", string sortDir = "desc")
        {
            if (string.IsNullOrWhiteSpace(authenticationToken)) throw new ArgumentException("Authentication token cannot be empty.");
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");
            if (string.IsNullOrWhiteSpace(portfolioId)) throw new ArgumentException("Portfolio ID cannot be empty.");
            if (string.IsNullOrWhiteSpace(startDate))
                startDate = DateTime.Now.Subtract(TimeSpan.FromDays(1)).ToString("s");

            return await this.portfolioEventService.GetAllPortfolioEvents(authenticationToken, endpoint, portfolioId, sortBy, sortDir, startDate);
        }

        /// <summary>
        /// Updates the event rule settings for the portfolio.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolio event rules endpoint.</param>
        /// <param name="portfolioId">ID of the portfolio to update the event rules in.</param>
        /// <param name="eventRuleSettings"><see cref="IEnumerable{EventRuleSetting}"/> with objects that contain the event rule settings.</param>
        /// <param name="countryCode">Two-letter country code (ISO 3166-1 alpha-2) for updating country-specific settings.</param>
        /// <returns>An asynchronous operation.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the parameters has an illegal value.
        /// </exception>
        public async Task UpdateEventRules(string authenticationToken, string endpoint, string portfolioId, IEnumerable<EventRuleSetting> eventRuleSettings, string countryCode = "XX")
        {
            if (string.IsNullOrWhiteSpace(authenticationToken)) throw new ArgumentException("Authentication token cannot be empty.");
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");
            if (string.IsNullOrWhiteSpace(portfolioId)) throw new ArgumentException("Portfolio ID cannot be empty.");

            IEnumerable<EventRuleSetting> ruleSettings = eventRuleSettings.ToList();
            if (!ruleSettings.ToList().Any()) throw new ArgumentException("Event Rule Settings cannot be empty.");

            await this.portfolioEventService.UpdateEventRules(authenticationToken, endpoint, portfolioId, countryCode, ruleSettings);
        }
    }
}
