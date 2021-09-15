using System;
using System.Collections.Generic;

#nullable disable

namespace DAL 
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int? MaritalStatus { get; set; }
        public byte[] CustomerPhoto { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
