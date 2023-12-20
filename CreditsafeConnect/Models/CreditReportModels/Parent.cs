namespace CreditsafeConnect.Models.CreditReportModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CompanyModels;

    public class Parent
    {
        public string Country { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
