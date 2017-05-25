using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Supporter { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Hotline { get; set; }
        public string Phone { get; set; }
        public string ZipcityId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
