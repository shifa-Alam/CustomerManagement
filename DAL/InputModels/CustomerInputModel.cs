using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public class CustomerInputModel
    {
        public CustomerInputModel()
        {
            CustomerAddresses = new List<CustomerAddressInputModel>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int? MaritalStatus { get; set; }
        public IFormFile File { get; set; }
        public byte[] CustomerPhoto { get; set; }

        public IList<CustomerAddressInputModel> CustomerAddresses { get; set; }
    }
}
