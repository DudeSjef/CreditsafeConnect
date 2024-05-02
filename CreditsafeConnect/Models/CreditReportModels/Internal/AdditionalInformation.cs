// <copyright file="AdditionalInformation.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System.Collections.Generic;

    /// <summary>
    /// A wrapper class for miscellaneous company information.
    /// </summary>
    public class AdditionalInformation
    {
        /// <summary>
        /// Gets or sets an object containing miscellaneous company information.
        /// </summary>
        public Misc Misc { get; set; }

        /// <summary>
        /// Gets or sets the list of trading names.
        /// </summary>
        public List<TradingStyle> TradingStyles { get; set; }
    }
}
