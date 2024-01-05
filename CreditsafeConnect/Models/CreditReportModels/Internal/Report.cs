namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Report
    {
        public string CompanyId { get; set; }
        public CompanySummary CompanySummary { get; set; }
        public CompanyIdentification CompanyIdentification { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public OtherInformation OtherInformation { get; set; }
        public AdditionalInformation AdditionalInformation { get; set; }
        public GroupStructure GroupStructure { get; set; }
    }
}
