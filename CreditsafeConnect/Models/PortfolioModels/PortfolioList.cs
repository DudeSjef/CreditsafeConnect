// <copyright file="PortfolioList.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.PortfolioModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Wrapper for the <see cref="Portfolio"/> class.
    /// </summary>
    internal class PortfolioList
    {
        /// <summary>
        /// Gets or sets the list of portfolios.
        /// </summary>
        public List<Portfolio> Portfolios { get; set; }
    }
}
