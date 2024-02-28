// <copyright file="CreditLimit.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing information about the company's credit limit.
    /// </summary>
    public class CreditLimit
    {
        /// <summary>
        /// Gets or sets the currency used for the company's credit limit.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value for the company's credit limit.
        /// </summary>
        public string Value { get; set; }
    }
}
