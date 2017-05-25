using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Computersoftware
    {
        public int ComputersoftwareId { get; set; }
        public int ComputerId { get; set; }
        public int SoftwareId { get; set; }
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
