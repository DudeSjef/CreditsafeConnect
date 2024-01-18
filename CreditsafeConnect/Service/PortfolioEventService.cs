// <copyright file="PortfolioEventService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    /// <inheritdoc cref="IPortfolioEventService"/>
    internal class PortfolioEventService : IPortfolioEventService
    {
        private readonly IPortfolioEventRepository portfolioEventRepository = new PortfolioEventRepository();

        /// <inheritdoc cref="IPortfolioEventService.GetAllPortfolioEvents"/>
        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(string authenticationToken, string endpoint, string portfolioId, string sortBy, string sortDir, string startDate, int page)
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>
            {
                { "sortBy", sortBy },
                { "sortDir", sortDir },
                { "startDate", startDate },
                { "page", page.ToString() },
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

        /// <inheritdoc cref="IPortfolioEventService.GetPortfolioEventsCount"/>
        public async Task<int> GetPortfolioEventsCount(string authenticationToken, string endpoint, string portfolioId, string startDate)
        {
            Dictionary<string, string> requestParameters = new Dictionary<string, string>
            {
                { "startDate", startDate },
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request getAllPortfolioEventsRequest = requestBuilder
                .Endpoint(endpoint)
                .PathParameters($"{portfolioId}/notificationEvents")
                .RequestParameters(requestParameters)
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.portfolioEventRepository.GetPortfolioEventsCount(getAllPortfolioEventsRequest);
        }

        /// <inheritdoc cref="IPortfolioEventService.UpdateEventRules"/>
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
