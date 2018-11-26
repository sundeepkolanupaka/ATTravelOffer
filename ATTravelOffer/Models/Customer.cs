using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATTravelOffer.Models
{
    public class Customer
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
    }
}