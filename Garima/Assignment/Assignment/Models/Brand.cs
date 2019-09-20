using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Brand
    {
        public int Pid { get; set; }
        public int? Bid { get; set; }
        public string Bname { get; set; }

        public virtual Orders B { get; set; }
    }
}
