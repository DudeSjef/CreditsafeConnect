// <copyright file="OtherInformation.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing a collection of employee counts per year.
    /// </summary>
    public class OtherInformation
    {
        /// <summary>
        /// Gets or sets a list of company employee count objects.
        /// </summary>
        public EmployeesInformation[] EmployeesInformation { get; set; }
    }
}
