// <copyright file="CompanyController.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using CreditsafeConnect.Models.CompanyModels;
    using CreditsafeConnect.Service;
    using CreditsafeConnect.Service.Interfaces;

    /// <summary>
    /// Application entry point for getting brief company information.<br/><br/>
    /// See <seealso cref="CreditReportController"/> for extended company information.
    /// </summary>
    public class CompanyController
    {
        private readonly ICompanyService companyService = new CompanyService();

        /// <summary>
        /// Gets a list of companies based on the given criteria.
        /// </summary>
        /// <param name="authenticationToken">Authentication token to be sent in the authentication header.</param>
        /// <param name="endpoint">URI of the companies endpoint.</param>
        /// <param name="countries">Comma-separated list of two-letter country codes (ISO 3166-1 alpha-2) for the countries to search in.</param>
        /// <param name="name">Name of the company to be searched for.</param>
        /// <param name="city">City of the company to be searched in. Omit parameter to search in all cities.</param>
        /// <param name="status">Status of the company to be searched for. Omit parameter to search for all statuses.</param>
        /// <param name="pageSize">Number of companies to retrieve. Value should be between 1 and 100. The default value is 20.</param>
        /// <returns>List of <see cref="Company"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when one of the parameters has an illegal value.
        /// </exception>
        public async Task<IEnumerable<Company>> GetCompanies(string authenticationToken, string endpoint, string countries, string name, [Optional] string city, [Optional] string status, int pageSize = 50)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken)) throw new ArgumentException("Authentication token cannot be empty.");
            if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Endpoint cannot be empty.");
            if (string.IsNullOrWhiteSpace(countries)) throw new ArgumentException("At least one country must be selected.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
            if (!string.IsNullOrWhiteSpace(status))
            {
                if (!Enum.IsDefined(typeof(Status), status)) throw new ArgumentException("Status is not of valid type.");
            }

            if (pageSize < 0 || pageSize > 100) throw new ArgumentException("Page size must be at least one and smaller than or equal to 100.");

            return await this.companyService.GetCompanies(authenticationToken, endpoint, countries, name, city, status, pageSize);
        }
    }
}
