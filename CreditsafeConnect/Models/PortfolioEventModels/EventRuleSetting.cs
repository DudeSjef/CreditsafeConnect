// <copyright file="EventRuleSetting.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.PortfolioEventModels
{
    /// <summary>
    /// Class to toggle a portfolio event rule.
    /// </summary>
    public class EventRuleSetting
    {
        /// <summary>
        /// Gets or sets a value indicating whether the event rule is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the event rule code.
        /// </summary>
        public int RuleCode { get; set; }
    }
}
