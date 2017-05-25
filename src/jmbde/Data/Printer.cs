using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Printer
    {
        public int PrinterId { get; set; }
        public int DevicenameId { get; set; }
        public string Serialnumber { get; set; }
        public string Network { get; set; }
        public string NetworkName { get; set; }
        public string NetworkIpaddress { get; set; }
        public bool isActive { get; set; }
        public bool shouldReplace { get; set; }
        public string Resources { get; set; }
        public string PapersizeMax { get; set; }
        public bool isColor { get; set; }
        public int DevicetypeId { get; set; }
        public int? EmployeeId { get; set; }
        public int PlaceId { get; set; }
        public int DepartmentId { get; set; }
        public int ManufacturerId { get; set; }
        public int InventoryId { get; set; }
        public int ComputerId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
