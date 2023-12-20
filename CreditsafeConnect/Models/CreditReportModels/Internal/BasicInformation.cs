namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CompanyModels;

    public class BasicInformation
    {
        public DateTime CompanyRegistrationDate { get; set; }
        public DateTime OperationsStartDate { get; set; }
        public LegalForm LegalForm { get; set; }
        public OfficeType OfficeType { get; set; }
    }
}
