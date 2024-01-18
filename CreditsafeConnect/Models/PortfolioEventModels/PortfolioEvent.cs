// <copyright file="PortfolioEvent.cs" company="Multitube Engineering B.V.">
// Copyright (c) Multitube Engineering B.V. All rights reserved.
// </copyright>

namespace CreditsafeConnect.Models.PortfolioEventModels
{
    using System;

    public class PortfolioEvent
    {
        public EventCompany Company { get; set; }

        public DateTime EventDate { get; set; }

        public string NewValue { get; set; }

        public string OldValue { get; set; }

        public int RuleCode { get; set; }

        public string RuleName { get; set; }

        public string LocalEventCode { get; set; }
    }
}
