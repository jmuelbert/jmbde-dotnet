using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Computer
    {
        public long ComputerId { get; set; }
        public long DevicenameId { get; set; }
        public string Serialnumber { get; set; }
        public string ServiceTag { get; set; }
        public string ServiceNumber { get; set; }
        public long? Memory { get; set; }
        public string Network { get; set; }
        public string NetworkName { get; set; }
        public string NetworkIpaddress { get; set; }
        public string Active { get; set; }
        public string Replace { get; set; }
        public long DevicetypeId { get; set; }
        public long? EmployeeId { get; set; }
        public long PlaceId { get; set; }
        public long DepartmentId { get; set; }
        public long ManufacturerId { get; set; }
        public long InventoryId { get; set; }
        public long ProcessorId { get; set; }
        public long OsId { get; set; }
        public long ComputersoftwareId { get; set; }
        public long? PrinterId { get; set; }
        public string LastUpdate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
