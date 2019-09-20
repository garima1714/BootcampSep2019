using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Brand = new HashSet<Brand>();
        }

        public int Bid { get; set; }
        public string Pname { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }
    }
}
