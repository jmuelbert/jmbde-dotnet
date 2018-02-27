using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Function
    {
        public long FunctionId { get; set; }
        public string Name { get; set; }
        public long? Priority { get; set; }
        public string LastUpdate { get; set; }
    }
}
