using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class EmployeeDocument
    {
        public long EmployeeDocumentId { get; set; }
        public long? EmployeeId { get; set; }
        public long? DocumentId { get; set; }
        public string LastUpdate { get; set; }
    }
}
