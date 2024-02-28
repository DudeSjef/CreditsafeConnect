// <copyright file="ICompanyRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// Data access class for brief company information.<br/><br/>
    /// See <seealso cref="ICreditReportRepository"/> for extended company information.
    /// </summary>
    internal interface ICompanyRepository
    {
        /// <summary>
        /// Calls the <see cref="Service.HttpClients.CompanyHttpClient.GetCompanies"/> method in the <see cref="Service.HttpClients.CompanyHttpClient"/>.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with company search criteria in the request parameter.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        Task<IEnumerable<Company>> GetCompanies(Request getCompaniesRequest);
    }
}
