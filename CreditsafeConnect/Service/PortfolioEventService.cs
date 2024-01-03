namespace CreditsafeConnect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.PortfolioEventModels;
    using Repository;
    using Repository.Interfaces;

    internal class PortfolioEventService : IPortfolioEventService
    {
        private readonly IPortfolioEventRepository portfolioEventRepository = new PortfolioEventRepository();

        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(string authenticationToken, string endpoint, string portfolioId)
        {
            RequestBuilder requestBuilder = new RequestBuilder();
            Request getAllPortfolioEventsRequest = requestBuilder
                .Endpoint(endpoint)
                .PathParameters($"{portfolioId}/notificationEvents")
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.portfolioEventRepository.GetAllPortfolioEvents(getAllPortfolioEventsRequest);
        }
    }
}
