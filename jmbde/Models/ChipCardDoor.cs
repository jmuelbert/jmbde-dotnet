using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class ChipCardDoor
    {
        public long ChipCardDoorId { get; set; }
        public string Number { get; set; }
        public long? PlaceId { get; set; }
        public long? DepartmentId { get; set; }
        public long? EmployeeId { get; set; }
        public string LastUpdate { get; set; }
    }
}
