namespace CreditsafeConnect.Models.CreditReportModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CompanyModels;
    using Internal;

    public class CreditReportResult
    {
        public string CreditsafefId { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public General General { get; set; }
        public Financial Financial { get; set; }

        public override string ToString()
        {
            return
                $"{Name}, {General.VisitingAddress.Street} {General.VisitingAddress.HouseNumber}, {General.VisitingAddress.City}, {General.VisitingAddress.PostalCode}, {General.VisitingAddress.Country}";
        }
    }
}
