using System;
using System.Collections.Generic;

namespace jmbde.Models
{
    public partial class Account
    {
        public long AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long? SystemDataId { get; set; }
        public string LastUpdate { get; set; }
    }
}
