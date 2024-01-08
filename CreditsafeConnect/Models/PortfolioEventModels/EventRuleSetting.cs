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
        /// Initializes a new instance of the <see cref="EventRuleSetting"/> class.
        /// </summary>
        /// <param name="ruleCode">Code of the event rule.</param>
        /// <param name="isActive">Determines whether or not the event rule is active.</param>
        public EventRuleSetting(int ruleCode, int isActive)
        {
            this.ruleCode = ruleCode;
            this.isActive = isActive;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event rule is active or not.
        /// </summary>
        #pragma warning disable SA1300
        public int isActive { get; set; }

        /// <summary>
        /// Gets or sets the event rule code.
        /// </summary>
        public int ruleCode { get; set; }
        #pragma warning restore SA1300 // Element should begin with upper-case letter
    }
}
