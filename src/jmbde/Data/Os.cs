using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Os
    {
        public int  OsId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string Fix { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
