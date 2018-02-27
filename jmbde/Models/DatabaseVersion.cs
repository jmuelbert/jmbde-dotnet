using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class DatabaseVersion
    {
        public long DatabaseVersionId { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string Patch { get; set; }
        public string LastUpdate { get; set; }
    }
}
