using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Databaseversion
    {
        public int DatabaseversionId { get; set; }
        public long? Version { get; set; }
        public long? Revision { get; set; }
        public long? Patch { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
