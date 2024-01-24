// <copyright file="CompanyService.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models;
    using CreditsafeConnect.Models.CompanyModels;
    using CreditsafeConnect.Repository;
    using CreditsafeConnect.Repository.Interfaces;
    using CreditsafeConnect.Service.Interfaces;

    /// <inheritdoc cref="ICompanyService"/>
    internal class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companiesRepository = new CompanyRepository();

        /// <inheritdoc cref="ICompanyService.GetCompanies"/>
        public async Task<IEnumerable<Company>> GetCompanies(string authenticationToken, string endpoint, string countries, string name, string status, int pageSize)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "countries", countries },
                { "name", name },
                { "pageSize", pageSize.ToString() },
            };

            if (!string.IsNullOrWhiteSpace(status))
            {
                parameters.Add("status", status);
            }

            RequestBuilder requestBuilder = new RequestBuilder();
            Request getCompaniesRequest = requestBuilder
                .Endpoint(endpoint)
                .RequestParameters(parameters)
                .AuthenticationHeader(authenticationToken)
                .Build();

            return await this.companiesRepository.GetCompanies(getCompaniesRequest);
        }
    }
}
