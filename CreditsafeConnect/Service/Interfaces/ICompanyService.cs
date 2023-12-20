// <copyright file="ICompanyService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// Service class for handling companies requests.
    /// </summary>
    internal interface ICompanyService
    {
        /// <summary>
        /// Calls the GetCompanies method in the repository layer.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the companies endpoint.</param>
        /// <param name="countries">Comma-separated list of two-letter countries codes (ISO 3166-1 alpha-2) for the countries to search in.</param>
        /// <param name="name">Name of the company to be searched for.</param>
        /// <param name="status">Status of the company to be searched for. The default value is <see cref="Status.Active"/>.</param>
        /// <param name="pageSize">Number of companies to retrieve. Value should be between 1 and 100. The default value is 20.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        Task<IEnumerable<Company>> GetCompanies(string authenticationToken, string endpoint, string countries, string name, string status = "Active", int pageSize = 20);
    }
}
