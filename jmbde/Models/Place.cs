using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Place
    {
        public long PlaceId { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public string Desk { get; set; }
        public string LastUpdate { get; set; }
    }
}
