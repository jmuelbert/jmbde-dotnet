using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class ZipCode
    {
        public long ZipCodeId { get; set; }
        public string Code { get; set; }
        public string LastUpdate { get; set; }
    }
}
