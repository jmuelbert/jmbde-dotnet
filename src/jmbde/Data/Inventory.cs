using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Inventory
    {
        public long InventoryId { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public string Active { get; set; }
        public string LastUpdate { get; set; }
    }
}
