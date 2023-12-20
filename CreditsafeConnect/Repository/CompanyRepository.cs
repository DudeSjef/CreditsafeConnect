﻿// <copyright file="CompanyRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CompanyModels;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.HttpClients;
    using CreditsafeConnect.Service.HttpClients.Interfaces;

    /// <inheritdoc cref="ICompanyRepository"/>
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly ICompanyHttpClient companyHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRepository"/> class.
        /// </summary>
        internal CompanyRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.companyHttpClient = new CompanyHttpClient(httpClient);
        }

        /// <summary>
        /// Calls the <see cref="CompanyHttpClient.GetCompanies"/> method in the <see cref="CompanyHttpClient"/>.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with company search criteria in the request parameter.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        public async Task<IEnumerable<Company>> GetCompanies(Request getCompaniesRequest)
        {
            return await this.companyHttpClient.GetCompanies(getCompaniesRequest);
        }
    }
}
