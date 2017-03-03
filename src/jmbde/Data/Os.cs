using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Os
    {
        public long OsId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string Fix { get; set; }
        public string LastUpdate { get; set; }
    }
}
