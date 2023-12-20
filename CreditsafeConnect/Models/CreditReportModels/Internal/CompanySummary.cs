namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanySummary
    {
        public string BusinessName { get; set; }
        public string Country { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public MainActivity MainActivity { get; set; }
        public CompanyStatus CompanyStatus { get; set; }
        public CreditRating CreditRating { get; set; }
    }
}
