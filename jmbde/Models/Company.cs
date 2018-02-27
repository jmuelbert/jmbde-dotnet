using System;
using System.Collections.Generic;
namespace jmbde.Models

{
    public partial class Company
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Address { get; set; }
        public long? ZipCityId { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string MobileNumber { get; set; }
        public string MailAddress { get; set; }
        public string Active { get; set; }
        public long? EmployeeId { get; set; }
        public string LastUpdate { get; set; }
    }
}
