using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Documents
    {
        public int DocumentsId { get; set; }
        public string Name { get; set; }
        public byte[] Document { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
