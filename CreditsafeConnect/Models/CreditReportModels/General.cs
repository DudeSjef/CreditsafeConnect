﻿namespace CreditsafeConnect.Models.CreditReportModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Internal;

    public class General
    {
        public string Language { get; set; }
        public CreditReportAddress VisitingAddress { get; set; }
        public CreditReportAddress PostalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}