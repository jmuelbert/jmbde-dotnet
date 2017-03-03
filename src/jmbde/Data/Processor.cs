using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Processor
    {
        public long ProcessorId { get; set; }
        public string Name { get; set; }
        public string Ghz { get; set; }
        public long? Cores { get; set; }
        public string LastUpdate { get; set; }
    }
}
