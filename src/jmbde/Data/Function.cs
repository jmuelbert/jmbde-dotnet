using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Function
    {
        public long FunctionId { get; set; }
        public string Name { get; set; }
        public long? Prio { get; set; }

        public string LastUpdate { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
