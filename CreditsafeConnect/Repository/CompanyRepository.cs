// <copyright file="CompanyRepository.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Repository
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service;
    using CreditsafeConnect.Service.Interfaces;

    /// <inheritdoc cref="ICompanyRepository"/>
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly ICreditsafeHttpClient creditsafeHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRepository"/> class.
        /// </summary>
        internal CompanyRepository()
        {
            HttpClient httpClient = new HttpClient();

            this.creditsafeHttpClient = new CreditsafeHttpClient(httpClient);
        }

        /// <summary>
        /// Calls the <see cref="CreditsafeHttpClient.GetCompanies"/> method in the <see cref="CreditsafeHttpClient"/>.
        /// </summary>
        /// <param name="getCompaniesRequest">Request object with company search criteria in the request parameter.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        public async Task<IEnumerable<Company>> GetCompanies(Request getCompaniesRequest)
        {
            return await this.creditsafeHttpClient.GetCompanies(getCompaniesRequest);
        }
    }
}
