using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
