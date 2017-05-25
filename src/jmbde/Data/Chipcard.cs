using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Chipcard
    {
        public Chipcard() {
           
        }
        public int ChipcardId { get; set; }

        public bool isActive { get; set; }
        public string Nummer { get; set; }
        public int? EmployeeId { get; set; }  
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

    }
}
