// <copyright file="LegalForm.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    /// <summary>
    /// A class containing information about the company legal form.
    /// </summary>
    public class LegalForm
    {
        /// <summary>
        /// Gets or sets the common code for the company's legal form.
        /// </summary>
        public string CommonCode { get; set; }

        /// <summary>
        /// Gets or sets the numeric code for the company's legal form.
        /// </summary>
        public string ProviderCode { get; set; }

        /// <summary>
        /// Gets or sets the description for the company's legal form.
        /// </summary>
        public string Description { get; set; }
    }
}
