using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool Active { get; set; }
        public bool Replace { get; set; }
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

        [DataType(DataType.DateTime)]
        public string LastUpdate { get; set; }


        // Navigation Properties
        public virtual Devicename Devicename { get; set; }
        public virtual Devicetype Devicetype { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Processor Processor { get; set; }
        public virtual Os Os { get; set; }
        public virtual ICollection<Computersoftware> Computersoftware { get; set; }
        public virtual Printer Printer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
