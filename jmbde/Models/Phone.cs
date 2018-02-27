using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Phone
    {
        public long PhoneId { get; set; }
        public long? DeviceNameId { get; set; }
        public string SerialNumber { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public string Active { get; set; }
        public string Replace { get; set; }
        public long? DeviceTypeId { get; set; }
        public long? EmployeeId { get; set; }
        public long? PlaceId { get; set; }
        public long? DepartmentId { get; set; }
        public long? ManufacturerId { get; set; }
        public long? InventoryId { get; set; }
        public string LastUpdate { get; set; }
    }
}
