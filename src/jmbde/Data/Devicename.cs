using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Devicename
    {
        public int DevicenameId { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
