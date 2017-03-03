using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Databaseversion
    {
        public long DatabaseversionId { get; set; }
        public long? Version { get; set; }
        public long? Revision { get; set; }
        public long? Patch { get; set; }
        public string LastUpdate { get; set; }
    }
}
