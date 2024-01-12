// <copyright file="BasicInformation.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using CreditsafeConnect.Models.CompanyModels;

    /// <summary>
    /// A Class containing basic company information.
    /// </summary>
    public class BasicInformation
    {
        /// <summary>
        /// Gets or sets the company's registration date.
        /// </summary>
        public DateTime CompanyRegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the company's VAT number.
        /// </summary>
        public string VatRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the start date of company's operations.
        /// </summary>
        public DateTime OperationsStartDate { get; set; }

        /// <summary>
        /// Gets or sets the company's legal form.
        /// </summary>
        public LegalForm LegalForm { get; set; }

        /// <summary>
        /// Gets or sets the company's office type.
        /// </summary>
        public OfficeType OfficeType { get; set; }
    }
}
