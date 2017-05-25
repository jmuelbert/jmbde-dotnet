using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Processor
    {
        public int ProcessorId { get; set; }
        public string Name { get; set; }
        public float Ghz { get; set; }
        public int? Cores { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
