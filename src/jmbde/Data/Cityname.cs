using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Cityname
    {
        public int CitynameId { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
