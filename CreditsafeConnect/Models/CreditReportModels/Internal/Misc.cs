// <copyright file="Misc.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    /// <summary>
    /// A class containing miscellaneous company information.
    /// </summary>
    public class Misc
    {
        /// <summary>
        /// Gets or sets the mobile phone number
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Gets or sets the RSIN number.
        /// </summary>
        public string RsinNumber { get; set; }

        /// <summary>
        /// Gets or sets the branch identifier number.
        /// </summary>
        public string BranchNumber { get; set; }

        /// <summary>
        /// Gets or sets the company's registration location.
        /// </summary>
        public string StatutaireSeal { get; set; }
    }
}
