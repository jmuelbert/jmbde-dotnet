using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Documents
    {
        public long DocumentsId { get; set; }
        public string Name { get; set; }
        public byte[] Document { get; set; }
        public string LastUpdate { get; set; }
    }
}
