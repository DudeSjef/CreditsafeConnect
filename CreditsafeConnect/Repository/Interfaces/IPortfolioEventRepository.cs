namespace CreditsafeConnect.Repository.Interfaces
{
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IPortfolioEventRepository
    {
        Task<List<PortfolioEvent>> GetAllPortfolioEvents(Request getAllPortfolioEventsRequest);
    }
}
