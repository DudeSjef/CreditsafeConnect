namespace CreditsafeConnect.Models.CreditReportModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Internal;

    public class Financial
    {
        public string RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal CreditLimit { get; set; }
        public string CreditScore { get; set; }
        public string Currency { get; set; }
        public string EoriNumber { get; set; }
        public Parent UltimateParent { get; set; }
        public Parent ImmediateParent { get; set; }
        public int Employees { get; set; }
        public LegalForm LegalForm { get; set; }
    }
}
