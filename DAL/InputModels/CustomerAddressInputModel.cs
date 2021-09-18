using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public  class CustomerAddressInputModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
    }
}
