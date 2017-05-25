using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Software
    {
        public int SoftwareId { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        public int Revision { get; set; }
        public int  Fix { get; set; }
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
