using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class ChipCardProfile
    {
        public long ChipCardProfileId { get; set; }
        public string Number { get; set; }
        public long? ChipCardDoorId { get; set; }
        public long? EmployeeId { get; set; }
        public string LastUpdate { get; set; }
    }
}
