namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Models.PortfolioModels;

    internal interface IPortfolioHttpClient
    {
        Task<List<Portfolio>> GetAllPortfolios(Request getAllPortfoliosRequest);
        Task CreatePortfolio(Request createPortfolioRequest);
        Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest);
        Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest);
    }
}
