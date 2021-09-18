using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public class CountryInputModel
    {
        public CountryInputModel()
        {
            Customers = new List<CustomerInputModel>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public IList<CustomerInputModel> Customers { get; set; }
    }
}
