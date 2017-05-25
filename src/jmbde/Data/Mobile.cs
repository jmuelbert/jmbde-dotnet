using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Mobile
    {
        public int MobileId { get; set; }
        public int DevicenameId { get; set; }
        public string Serialnumber { get; set; }
        public string Number { get; set; }
        public string Cardnumber { get; set; }
        public string Activatedate { get; set; }
        public string Pin { get; set; }
        public bool isActive { get; set; }
        public bool shouldReplace { get; set; }
        public int DevicetypeId { get; set; }
        public int? EmployeeId { get; set; }
        public int PlaceId { get; set; }
        public int DepartmentId { get; set; }
        public int ManufacturerId { get; set; }
        public int InventoryId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
