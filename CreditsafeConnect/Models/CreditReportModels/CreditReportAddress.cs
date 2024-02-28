// <copyright file="CreditReportAddress.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    /// <summary>
    /// A class containing information about a company's address.
    /// </summary>
    public class CreditReportAddress
    {
        /// <summary>
        /// Gets or sets the type of address.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the address addition.
        /// </summary>
        public string AdditionToAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the province.
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the company should be included in the mailing list or not.
        /// </summary>
        public bool DirectMarketingOptOut { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Overrides the default method for comparing two object of this class.
        /// </summary>
        /// <param name="other">The other object to compare against.</param>
        /// <returns>A boolean determining whether the two objects are equal or not.</returns>
        public bool Equals(CreditReportAddress other)
        {
            return this.Street == other.Street &&
                   this.HouseNumber == other.HouseNumber &&
                   this.City == other.City &&
                   this.PostalCode == other.PostalCode &&
                   this.Province == other.Province &&
                   this.Country == other.Country;
        }
    }
}
