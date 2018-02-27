using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Processor
    {
        public long ProcessorId { get; set; }
        public string Name { get; set; }
        public string ClockRate { get; set; }
        public long? Cores { get; set; }
        public string LastUpdate { get; set; }
    }
}
