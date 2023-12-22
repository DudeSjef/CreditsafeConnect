namespace CreditsafeConnect.Models.CreditReportModels.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreditReportAddress
    {
        public string Type { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }

        public bool Equals(CreditReportAddress other)
        {
            return this.Street == other.Street &&
                   this.HouseNumber == other.HouseNumber &&
                   this.City == other.City &&
                   this.PostalCode == other.PostalCode &&
                   this.Province == other.Province &&
                   this.Country == other.Country;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Type != null ? this.Type.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (this.Street != null ? this.Street.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.HouseNumber != null ? this.HouseNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.City != null ? this.City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PostalCode != null ? this.PostalCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Province != null ? this.Province.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Telephone != null ? this.Telephone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Country != null ? this.Country.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
