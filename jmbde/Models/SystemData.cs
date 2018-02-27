using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class SystemData
    {
        public long SystemDataId { get; set; }
        public string Name { get; set; }
        public string Local { get; set; }
        public long? CompanyId { get; set; }
        public string LastUpdate { get; set; }
    }
}
