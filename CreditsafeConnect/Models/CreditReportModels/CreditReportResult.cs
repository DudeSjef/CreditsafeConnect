// <copyright file="CreditReportResult.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// A class which contains the information from a Creditsafe Credit Report, mapped to more closely match the Ridder iQ database.
    /// </summary>
    public class CreditReportResult
    {
        /// <summary>
        /// Gets or sets the company ID used by Creditsafe.
        /// </summary>
        public string CreditsafeId { get; set; }

        /// <summary>
        /// Gets or sets the company's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company's status.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets an object containing general company information.
        /// </summary>
        public General General { get; set; }

        /// <summary>
        /// Gets or sets an object containing company financial information.
        /// </summary>
        public Financial Financial { get; set; }
    }
}
