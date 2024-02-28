// <copyright file="Parent.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// A class containing information about a company parent.
    /// </summary>
    public class Parent
    {
        /// <summary>
        /// Gets or sets the country of the company's parent.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the id of the company's parent.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the company's parent.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the company's parent.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the registration number of the company's parent.
        /// </summary>
        public string RegistrationNumber { get; set; }
    }
}
