// <copyright file="CompanyStatus.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// A wrapper class for the company's status.
    /// </summary>
    public class CompanyStatus
    {
        /// <summary>
        /// Gets or sets the company's status.
        /// </summary>
        public Status Status { get; set; }
    }
}
