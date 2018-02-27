using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class ChipCardProfileDoor
    {
        public long ChipCardProfileDoorId { get; set; }
        public long? ChipCardProfileId { get; set; }
        public long? ChipCardDoorId { get; set; }
        public string LastUpdate { get; set; }
    }
}
