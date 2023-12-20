namespace CreditsafeConnect.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.PortfolioModels;
    using Repository;
    using Repository.Interfaces;

    internal class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository portfolioRepository = new PortfolioRepository();

        public async Task<List<Portfolio>> GetAllPortfolios(string authenticationToken, string endpoint)
        {
            RequestBuilder requestBuilder = new RequestBuilder();
            Request getAllPortfoliosRequest = requestBuilder
                .Endpoint(endpoint)
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.portfolioRepository.GetAllPortfolios(getAllPortfoliosRequest);
        }

        public async Task CreatePortfolio(string authenticationToken, string endpoint, string portfolioName)
        {
            object portfolio = new
            {
                name = portfolioName,
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request createPortfolioRequest = requestBuilder
                .Endpoint(endpoint)
                .Payload(portfolio)
                .AuthenticationHeader(authenticationToken)
                .Build();

            await this.portfolioRepository.CreatePortfolio(createPortfolioRequest);
        }

        public async Task AddCompanyToPortfolio(string authenticationToken, string endpoint, string portfolioId, string companyId)
        {
            object company = new
            {
                id = companyId,
                personalReference = string.Empty,
                freeText = string.Empty,
                personalLimit = "0.00",
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request addCompanyToPortfolioRequest = requestBuilder
                .Endpoint(endpoint)
                .Payload(company)
                .PathParameters($"{portfolioId}/companies")
                .AuthenticationHeader(authenticationToken)
                .Build();

            await this.portfolioRepository.AddCompanyToPortfolio(addCompanyToPortfolioRequest);
        }

        public async Task RemoveCompanyFromPortfolio(string authenticationToken, string endpoint, string portfolioId, string companyId)
        {
            RequestBuilder requestBuilder = new RequestBuilder();
            Request removeCompanyFromPortfolioRequest = requestBuilder
                .Endpoint(endpoint)
                .PathParameters($"{portfolioId}/companies/{companyId}")
                .AuthenticationHeader(authenticationToken)
                .Build();

            await this.portfolioRepository.RemoveCompanyFromPortfolio(removeCompanyFromPortfolioRequest);
        }
    }
}
