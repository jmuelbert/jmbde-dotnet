using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class ZipCity
    {
        public long ZipCityId { get; set; }
        public long? ZipCodeId { get; set; }
        public long? CityNameId { get; set; }
        public string LastUpdate { get; set; }
    }
}
