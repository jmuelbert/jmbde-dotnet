using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Manufacturer
    {
        public long ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Supporter { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public long? ZipCityId { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string HotlineNumber { get; set; }
        public string LastUpdate { get; set; }
    }
}
