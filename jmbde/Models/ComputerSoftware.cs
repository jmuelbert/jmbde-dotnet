using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class ComputerSoftware
    {
        public long ComputerSoftwareId { get; set; }
        public long? ComputerId { get; set; }
        public long? SoftwareId { get; set; }
        public string LastUpdate { get; set; }
    }
}
