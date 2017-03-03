using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Employeeaccount
    {
        public long EmployeeaccountId { get; set; }
        public long EmployeeId { get; set; }
        public long AccountId { get; set; }
        public string LastUpdate { get; set; }
    }
}
