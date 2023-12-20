namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Models.PortfolioEventModels;

    internal interface IPortfolioEventHttpClient
    {
        Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest);
    }
}
