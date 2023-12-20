namespace CreditsafeConnect.Service.Interfaces
{
    using CreditsafeConnect.Models.PortfolioEventModels;
    using CreditsafeConnect.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IPortfolioEventService
    {
        Task<List<PortfolioEvent>> GetAllPortfolioEvents(string authenticationToken, string endpoint, string portfolioId);
    }
}
