// <copyright file="Financial.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels
{
    using System;

    /// <summary>
    /// A class containing company financial information.
    /// </summary>
    public class Financial
    {
        /// <summary>
        /// Gets or sets the company's registration number.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the company's registration date.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the company's registration location.
        /// </summary>
        public string StatutoryAddress { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's main activity.
        /// </summary>
        public MainActivity MainActivity { get; set; }

        /// <summary>
        /// Gets or sets the company's credit limit.
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// Gets or sets the company's credit score.
        /// </summary>
        public string CreditScore { get; set; }

        /// <summary>
        /// Gets or sets the currency used for the credit limit.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the company's EORI number.
        /// </summary>
        public string EoriNumber { get; set; }

        /// <summary>
        /// Gets or sets the company's VAT number.
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's highest parent.
        /// </summary>
        public Parent UltimateParent { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's direct parent.
        /// </summary>
        public Parent ImmediateParent { get; set; }

        /// <summary>
        /// Gets or sets the number of employees.
        /// </summary>
        public int Employees { get; set; }

        /// <summary>
        /// Gets or sets the company's legal form.
        /// </summary>
        public string LegalForm { get; set; }
    }
}
