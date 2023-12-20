namespace CreditsafeConnect.Service.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.PortfolioModels;
    using Interfaces;
    using Models;
    using Models.PortfolioEventModels;
    using Newtonsoft.Json;
    using Properties;

    internal class PortfolioEventHttpClient : IPortfolioEventHttpClient
    {
        private readonly HttpClient httpClient;

        internal PortfolioEventHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(Resources.Url);

            this.httpClient = httpClient;
        }

        public async Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest)
        {
            this.httpClient.DefaultRequestHeaders.Authorization = getAllPortfolioEventsRequest.AuthenticationHeader;

            HttpResponseMessage response =
                await this.httpClient.GetAsync(getAllPortfolioEventsRequest.EndpointUri + getAllPortfolioEventsRequest.PathParameters);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<PortfolioEvent>>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
