using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Department
    {
        public long DepartmentId { get; set; }
        public string Name { get; set; }
        public long? Prio { get; set; }
        public long PrinterId { get; set; }
        public long FaxId { get; set; }
        public string LastUpdate { get; set; }
    }
}
