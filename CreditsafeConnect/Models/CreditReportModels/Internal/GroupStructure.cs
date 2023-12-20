namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GroupStructure
    {
        public Parent UltimateParent { get; set; }
        public Parent ImmediateParent { get; set; }
    }
}
