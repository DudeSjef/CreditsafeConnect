namespace CreditsafeConnect.Models.PortfolioEventModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PortfolioEvent
    {
        public DateTime EventDate { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public int RuleCode { get; set; }
        public string RuleName { get; set; }
    }
}
