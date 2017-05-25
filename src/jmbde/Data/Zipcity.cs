using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Zipcity
    {
        public int ZipcityId { get; set; }
        public int CitynameId { get; set; }
        public int ZipcodeId { get; set; }
        public int CityId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }
    }
}
