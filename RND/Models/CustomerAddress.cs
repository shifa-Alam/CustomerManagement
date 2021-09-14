using System;
using System.Collections.Generic;

#nullable disable

namespace RND.Models
{
    public partial class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
