using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Place
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public string Desk { get; set; }
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

    }
}
