using System;
using System.Collections.Generic;

#nullable disable

namespace RND.del
{
    public partial class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerAddress1 { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
