using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Zipcode
    {
        public int ZipcodeId { get; set; }
        public string Zipcode1 { get; set; }
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
