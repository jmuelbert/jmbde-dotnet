using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Account
    {
        public long AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long SystemdataId { get; set; }
        public string LastUpdate { get; set; }
    }
}
