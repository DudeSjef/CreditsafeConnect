namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreditRating
    {
        public string CommonValue { get; set; }
        public CreditLimit CreditLimit { get; set; }
        public ProviderValue ProviderValue { get; set; }
        public float PoD { get; set; }
    }
}
