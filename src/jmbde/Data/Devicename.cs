using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Devicename
    {
        public long DevicenameId { get; set; }
        public string Name { get; set; }
        public long ManufacturerId { get; set; }
        public string LastUpdate { get; set; }
    }
}
