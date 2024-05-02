// <copyright file="CreditRating.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing information about the company's credit rating.
    /// </summary>
    public class CreditRating
    {
        /// <summary>
        /// Gets or sets the character between A and E indicating the company's international credit score.
        /// </summary>
        public string CommonValue { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's credit limit.
        /// </summary>
        public CreditLimit CreditLimit { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's credit score.
        /// </summary>
        public ProviderValue ProviderValue { get; set; }

        /// <summary>
        /// Gets or sets a description about the company's credit score.
        /// </summary>
        public string ProviderDescription { get; set; }

        /// <summary>
        /// Gets or sets the number indicating the company's Probability of Default.
        /// </summary>
        public float PoD { get; set; }
    }
}
