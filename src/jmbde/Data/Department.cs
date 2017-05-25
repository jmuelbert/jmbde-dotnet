using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? Prio { get; set; }
        public int PrinterId { get; set; }
        public int FaxId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
