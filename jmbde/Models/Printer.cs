using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Printer
    {
        public long PrinterId { get; set; }
        public long? DeviceNameId { get; set; }
        public string SerialNumber { get; set; }
        public string Network { get; set; }
        public string NetworkName { get; set; }
        public string NetworkIpAddress { get; set; }
        public string Active { get; set; }
        public string Replace { get; set; }
        public string Resources { get; set; }
        public string PaperSizeMax { get; set; }
        public string Color { get; set; }
        public long? DeviceTypeId { get; set; }
        public long? EmployeeId { get; set; }
        public long? PlaceId { get; set; }
        public long? DepartmentId { get; set; }
        public long? ManufacturerId { get; set; }
        public long? InventoryId { get; set; }
        public long? ComputerId { get; set; }
        public string LastUpdate { get; set; }
    }
}
