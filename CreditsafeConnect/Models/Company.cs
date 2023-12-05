// <copyright file="Company.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models
{
    /// <summary>
    /// Class with brief company information.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Gets or sets the unique company identifier within Creditsafe.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the two-letter country code (ISO 3166-1 alpha-2) of the country the company is situated.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the company identifier associated with its domestic filing agency.
        /// </summary>
        public string RegNo { get; set; }

        /// <summary>
        /// Gets or sets the company VAT number.
        /// </summary>
        public string[] VatNo { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the company status.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the company office type.
        /// </summary>
        public OfficeType OfficeType { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers registered to the company.
        /// </summary>
        public string[] PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the code of the industry the company operates in.
        /// </summary>
        public string ActivityCode { get; set; }
    }
}
