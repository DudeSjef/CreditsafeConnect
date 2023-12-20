namespace CreditsafeConnect.Repository.Interfaces
{
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IPortfolioRepository
    {
        Task<List<Portfolio>> GetAllPortfolios(Request getAllPortfoliosRequest);
        Task CreatePortfolio(Request createPortfolioRequest);
        Task AddCompanyToPortfolio(Request addCompanyToPortfolioRequest);
        Task RemoveCompanyFromPortfolio(Request removeCompanyFromPortfolioRequest);
    }
}
