// <copyright file="PortfolioService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    /// <inheritdoc cref="IPortfolioService"/>
    internal class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository portfolioRepository = new PortfolioRepository();

        /// <inheritdoc cref="IPortfolioService.GetPortfoliosByName"/>
        public async Task<IEnumerable<Portfolio>> GetPortfoliosByName(string authenticationToken, string endpoint, string name)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "searchQuery", name },
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request getPortfoliosByNameRequest = requestBuilder
                .Endpoint(endpoint)
                .RequestParameters(parameters)
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.portfolioRepository.GetPortfoliosByName(getPortfoliosByNameRequest);
        }

        /// <inheritdoc cref="IPortfolioService.CreatePortfolio"/>
        public async Task CreatePortfolio(string authenticationToken, string endpoint, string name)
        {
            object portfolio = new
            {
                name,
            };

            RequestBuilder requestBuilder = new RequestBuilder();
            Request createPortfolioRequest = requestBuilder
                .Endpoint(endpoint)
                .Payload(portfolio)
                .AuthenticationHeader(authenticationToken)
                .Build();

            await this.portfolioRepository.CreatePortfolio(createPortfolioRequest);
        }

        /// <inheritdoc cref="IPortfolioService.AddCompanyToPortfolio"/>
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

        /// <inheritdoc cref="IPortfolioService.RemoveCompanyFromPortfolio"/>
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
