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
    using Models.PortfolioModels;
    using Service.HttpClients;
    using Service.HttpClients.Interfaces;

    internal class PortfolioRepository : IPortfolioRepository
    {
        private readonly IPortfolioHttpClient portfolioHttpClient;

        internal PortfolioRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.portfolioHttpClient = new PortfolioHttpClient(httpClient);
        }

        public async Task<List<Portfolio>> GetAllPortfolios(Request getAllPortfoliosRequest)
        {
            return await this.portfolioHttpClient.GetAllPortfolios(getAllPortfoliosRequest);
        }

        public async Task CreatePortfolio(Request createPortfolioRequest)
        {
            await this.portfolioHttpClient.CreatePortfolio(createPortfolioRequest);
        }

        public async Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest)
        {
            await this.portfolioHttpClient.AddCompanyToPortfolio(addCompanyToPortfolioRequest);
        }

        public async Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest)
        {
            await this.portfolioHttpClient.RemoveCompanyFromPortfolio(removeCompanyFromPortfolioRequest);
        }
    }
}
