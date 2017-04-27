using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Chipcard
    {
        public Chipcard() {
           
        }

        public long ChipcardId { get; set; }
        public string Nummer { get; set; }
        public long? EmployeeId { get; set; }
        public string LastUpdate { get; set; }
    }
}
