namespace CreditsafeConnect.Models.CreditReportModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LegalForm
    {
        public string CommonCode { get; set; }
        // 41 = BV
        public string ProviderCode { get; set; }
        public string Description { get; set; }
    }
}
