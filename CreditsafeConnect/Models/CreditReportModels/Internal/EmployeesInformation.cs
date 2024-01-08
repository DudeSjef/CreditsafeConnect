// <copyright file="EmployeesInformation.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing information about the number of employees per year.
    /// </summary>
    public class EmployeesInformation
    {
        /// <summary>
        /// Gets or sets the year of the employee count.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the number of employees.
        /// </summary>
        public string NumberOfEmployees { get; set; }
    }
}
