using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public bool isActive { get; set; }

        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
