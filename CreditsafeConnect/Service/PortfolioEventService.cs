// <copyright file="PortfolioEventService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    internal class PortfolioEventService : IPortfolioEventService
    {
        private readonly IPortfolioEventRepository portfolioEventRepository = new PortfolioEventRepository();

        /// <summary>
        /// Gets a list of all portfolio events.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolio events endpoint.</param>
        /// <param name="portfolioId">ID of the portfolio to retrieve the events from.</param>
        /// <param name="sortBy">Field to sort the results by. Default is eventDate.</param>
        /// <param name="sortDir">Direction to sort the results in. Default is descending.</param>
        /// <param name="startDate">Date to start retrieving events from.</param>
        /// <returns>List of <see cref="PortfolioEvent"/>.</returns>
        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(string authenticationToken, string endpoint, string portfolioId, string sortBy, string sortDir, string startDate)
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>()
            {
                { "sortBy", sortBy },
                { "sortDir", sortDir },
                { "startDate", startDate },
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request getAllPortfolioEventsRequest = requestBuilder
                .Endpoint(endpoint)
                .PathParameters($"{portfolioId}/notificationEvents")
                .RequestParameters(requestParameters)
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.portfolioEventRepository.GetAllPortfolioEvents(getAllPortfolioEventsRequest);
        }

        /// <summary>
        /// Updates the event rule settings for the portfolio.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the portfolio event rules endpoint.</param>
        /// <param name="portfolioId">ID of the portfolio to update the event rules in.</param>
        /// <param name="countryCode">Two-letter country code (ISO 3166-1 alpha-2) for updating country-specific settings.</param>
        /// <param name="eventRuleSettings"><see cref="IEnumerable{EventRuleSetting}"/> with objects that contain the event rule settings.</param>
        /// <returns>An asynchronous operation.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the parameters has an illegal value.
        /// </exception>
        public async Task UpdateEventRules(string authenticationToken, string endpoint, string portfolioId, string countryCode, IEnumerable<EventRuleSetting> eventRuleSettings)
        {
            RequestBuilder requestBuilder = new RequestBuilder();
            Request updateEventRulesRequest = requestBuilder
                .Endpoint(endpoint)
                .PathParameters($"{portfolioId}/eventRules/{countryCode}")
                .Payload(eventRuleSettings)
                .AuthenticationHeader(authenticationToken)
                .Build();

            await this.portfolioEventRepository.UpdateEventRules(updateEventRulesRequest);
        }
    }
}
