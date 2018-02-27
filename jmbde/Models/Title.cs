using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Title
    {
        public long TitleId { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string LastUpdate { get; set; }
    }
}
