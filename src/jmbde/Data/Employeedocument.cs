using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Employeedocument
    {
        public int EmployeedocumentId { get; set; }
        public int EmployeeId { get; set; }
        public int DocumentId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }        
    }
}
