namespace CreditsafeConnect.Service.Interfaces
{
    using CreditsafeConnect.Models.PortfolioModels;
    using CreditsafeConnect.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IPortfolioService
    {
        Task<List<Portfolio>> GetPortfoliosByName(string authenticationToken, string endpoint, string name);
        Task CreatePortfolio(string authenticationToken, string endpoint, string name);
        Task AddCompanyToPortfolio(string authenticationToken, string endpoint, string portfolioId, string companyId);
        Task RemoveCompanyFromPortfolio(string authenticationToken, string endpoint, string portfolioId, string companyId);
    }
}
