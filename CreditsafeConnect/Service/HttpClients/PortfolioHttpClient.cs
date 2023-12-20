namespace CreditsafeConnect.Service.HttpClients
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
    using Newtonsoft.Json;
    using Properties;

    internal class PortfolioHttpClient : IPortfolioHttpClient
    {
        private readonly HttpClient httpClient;

        internal PortfolioHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        public async Task<List<Portfolio>> GetAllPortfolios(Request getAllPortfoliosRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getAllPortfoliosRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getAllPortfoliosRequest.EndpointUri);

            response.EnsureSuccessStatusCode();

            PortfolioList portfolioList = JsonConvert.DeserializeObject<PortfolioList>(response.Content.ReadAsStringAsync().Result);

            return portfolioList.Portfolios;
        }

        public async Task CreatePortfolio(Request createPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = createPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PostAsync(createPortfolioRequest.EndpointUri, createPortfolioRequest.Payload);

            response.EnsureSuccessStatusCode();
        }

        public async Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = addCompanyToPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.PostAsync(addCompanyToPortfolioRequest.EndpointUri, addCompanyToPortfolioRequest.Payload);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = removeCompanyFromPortfolioRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.DeleteAsync(removeCompanyFromPortfolioRequest.EndpointUri +
                    removeCompanyFromPortfolioRequest.PathParameters);

            response.EnsureSuccessStatusCode();
        }
    }
}
