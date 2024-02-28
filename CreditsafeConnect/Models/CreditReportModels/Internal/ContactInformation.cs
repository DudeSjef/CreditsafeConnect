// <copyright file="ContactInformation.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing company contact information.
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Gets or sets an object containing information regarding the company's main address.
        /// </summary>
        public CreditReportAddress MainAddress { get; set; }

        /// <summary>
        /// Gets or sets a list of objects containing information regarding all the company's addresses, apart from its main address.
        /// </summary>
        public CreditReportAddress[] OtherAddresses { get; set; }

        /// <summary>
        /// Gets or sets a list of email addresses associated with the company.
        /// </summary>
        public string[] EmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets a list of website addresses associated with the company.
        /// </summary>
        public string[] Websites { get; set; }
    }
}
