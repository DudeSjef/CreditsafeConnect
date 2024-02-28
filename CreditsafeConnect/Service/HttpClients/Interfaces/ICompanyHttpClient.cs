// <copyright file="ICompanyHttpClient.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service.HttpClients.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// Class for handling company HTTP request.
    /// </summary>
    internal interface ICompanyHttpClient
    {
        /// <summary>
        /// Retrieves a list of companies.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with companies endpoint and company search criteria in the request parameters.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        Task<IEnumerable<Company>> GetCompanies(Request getCompaniesRequest);
    }
}
