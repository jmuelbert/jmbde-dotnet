using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Systemdata
    {
        public long SystemdataId { get; set; }
        public string Name { get; set; }
        public string Local { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public long AccountId { get; set; }
        public string LastUpdate { get; set; }
    }
}
