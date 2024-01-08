// <copyright file="General.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    using CreditsafeConnect.Models.CreditReportModels.Internal;

    /// <summary>
    /// A class containing general company information.
    /// </summary>
    public class General
    {
        /// <summary>
        /// Gets or sets the company's language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's visiting address.
        /// </summary>
        public CreditReportAddress VisitingAddress { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's postal address.
        /// </summary>
        public CreditReportAddress PostalAddress { get; set; }

        /// <summary>
        /// Gets or sets the company's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the company's main email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the company's main website address.
        /// </summary>
        public string Website { get; set; }
    }
}
