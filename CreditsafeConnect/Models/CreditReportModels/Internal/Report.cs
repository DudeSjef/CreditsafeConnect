// <copyright file="Report.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System.Collections.Generic;

    /// <summary>
    /// A class containing all the information about a company's credit report.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// Gets or sets an object containing a summary of company information.
        /// </summary>
        public CompanySummary CompanySummary { get; set; }

        /// <summary>
        /// Gets or sets a wrapper object for basic company information.
        /// </summary>
        public CompanyIdentification CompanyIdentification { get; set; }

        /// <summary>
        /// Gets or sets an object containing company contact information.
        /// </summary>
        public ContactInformation ContactInformation { get; set; }

        /// <summary>
        /// Gets or sets an object containing a collection of employee counts per year.
        /// </summary>
        public OtherInformation OtherInformation { get; set; }

        /// <summary>
        /// Gets or sets an object containing miscellaneous company information.
        /// </summary>
        public AdditionalInformation AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets an object containing a collection of the company's parents.
        /// </summary>
        public GroupStructure GroupStructure { get; set; }

        /// <summary>
        /// Gets or sets an object containing a collection of the company's affiliates.
        /// </summary>
        public List<Parent> ExtendedGroupStructure { get; set; }
    }
}
