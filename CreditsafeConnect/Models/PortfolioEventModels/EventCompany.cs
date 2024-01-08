// <copyright file="EventCompany.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.PortfolioEventModels
{
    /// <summary>
    /// Company information in an <see cref="PortfolioEvent"/> object.
    /// </summary>
    public class EventCompany
    {
        /// <summary>
        /// Gets or sets the company unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string Name { get; set; }
    }
}
