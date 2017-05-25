using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Data
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SystemdataId { get; set; }  
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

    }
}
