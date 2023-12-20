// <copyright file="Address.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CompanyModels
{
    /// <summary>
    /// Class with company address information.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the company address street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the company address house number.
        /// </summary>
        public string HouseNo { get; set; }

        /// <summary>
        /// Gets or sets the company address city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the company address post code.
        /// </summary>
        public string PostCode { get; set; }
    }
}
