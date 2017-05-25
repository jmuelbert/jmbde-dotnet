using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Systemdata
    {
        public int SystemdataId { get; set; }
        public string Name { get; set; }
        public Boolean isLocal { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int AccountId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
