// <copyright file="GroupStructure.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing a collection of the company's parents.
    /// </summary>
    public class GroupStructure
    {
        /// <summary>
        /// Gets or sets an object containing information about the company's highest parent.
        /// </summary>
        public Parent UltimateParent { get; set; }

        /// <summary>
        /// Gets or sets an object containing information about the company's direct parent.
        /// </summary>
        public Parent ImmediateParent { get; set; }
    }
}
