using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
