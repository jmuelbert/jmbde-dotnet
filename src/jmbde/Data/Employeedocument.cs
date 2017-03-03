using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Employeedocument
    {
        public long EmployeedocumentId { get; set; }
        public long EmployeeId { get; set; }
        public long DocumentId { get; set; }
        public string LastUpdate { get; set; }
    }
}
