using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class EmployeeAccount
    {
        public long EmployeeAccountId { get; set; }
        public long? EmployeeId { get; set; }
        public long? AccountId { get; set; }
        public string LastUpdate { get; set; }
    }
}
