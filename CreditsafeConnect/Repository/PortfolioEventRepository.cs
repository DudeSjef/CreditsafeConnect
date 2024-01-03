namespace CreditsafeConnect.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.PortfolioEventModels;
    using Service.HttpClients;
    using Service.HttpClients.Interfaces;

    internal class PortfolioEventRepository : IPortfolioEventRepository
    {
        private readonly IPortfolioEventHttpClient portfolioEventHttpClient;

        internal PortfolioEventRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.portfolioEventHttpClient = new PortfolioEventHttpClient(httpClient);
        }


        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest)
        {
            return await this.portfolioEventHttpClient.GetAllPortfolioEvents(getAllPortfolioEventsRequest);
        }
    }
}
