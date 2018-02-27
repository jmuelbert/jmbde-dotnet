using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Document
    {
        public long DocumentId { get; set; }
        public string Name { get; set; }
        public byte[] DocumentData { get; set; }
        public string LastUpdate { get; set; }
    }
}
