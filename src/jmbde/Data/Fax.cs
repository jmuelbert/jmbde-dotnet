using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Fax
    {
        public long FaxId { get; set; }
        public long DevicenameId { get; set; }
        public string Serialnumber { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public string Active { get; set; }
        public string Replace { get; set; }
        public long DevicetypeId { get; set; }
        public long? EmployeeId { get; set; }
        public long PlaceId { get; set; }
        public long DepartmentId { get; set; }
        public long ManufacturerId { get; set; }
        public long InventoryId { get; set; }
        public long PrinterId { get; set; }
        public string LastUpdate { get; set; }
    }
}
