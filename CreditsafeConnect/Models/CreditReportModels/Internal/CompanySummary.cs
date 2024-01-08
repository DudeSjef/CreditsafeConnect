// <copyright file="CompanySummary.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing a summary of company information.
    /// </summary>
    public class CompanySummary
    {
        /// <summary>
        /// Gets or sets the company's name.
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// Gets or sets the company's country with a two-letter country code (ISO 3166-1 alpha-2).
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the company's registration number.
        /// </summary>
        public string CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets an object containing the company's main activity.
        /// </summary>
        public MainActivity MainActivity { get; set; }

        /// <summary>
        /// Gets or sets an object containing the company's status.
        /// </summary>
        public CompanyStatus CompanyStatus { get; set; }

        /// <summary>
        /// Gets or sets an object containing the company's credit rating.
        /// </summary>
        public CreditRating CreditRating { get; set; }
    }
}
