namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ContactInformation
    {
        public CreditReportAddress MainAddress { get; set; }
        public CreditReportAddress[] OtherAddresses { get; set; }
        public string[] EmailAddresses { get; set; }
        public string[] Websites { get; set; }
    }
}
