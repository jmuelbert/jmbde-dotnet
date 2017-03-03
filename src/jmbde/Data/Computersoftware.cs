using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Computersoftware
    {
        public long ComputersoftwareId { get; set; }
        public long ComputerId { get; set; }
        public long SoftwareId { get; set; }
        public string LastUpdate { get; set; }
    }
}
