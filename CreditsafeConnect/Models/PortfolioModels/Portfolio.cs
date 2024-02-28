// <copyright file="Portfolio.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.PortfolioModels
{
    /// <summary>
    /// Collection of companies used for monitoring changes in company information.
    /// </summary>
    public class Portfolio
    {
        /// <summary>
        /// Gets or sets the portfolio unique identifier.
        /// </summary>
        public string PortfolioId { get; set; }

        /// <summary>
        /// Gets or sets the portfolio name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the portfolio is the default portfolio.
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
