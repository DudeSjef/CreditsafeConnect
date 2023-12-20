// <copyright file="CompanyList.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CompanyModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Wrapper for the <see cref="Company"/> class.
    /// </summary>
    internal class CompanyList
    {
        /// <summary>
        /// Gets or sets the list of companies.
        /// </summary>
        public List<Company> Companies { get; set; }
    }
}
