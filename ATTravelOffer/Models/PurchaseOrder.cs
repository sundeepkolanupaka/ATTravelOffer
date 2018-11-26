using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ATTravelOffer.Models
{
    public class PurchaseOrder
    {
        public Int64 ID { get; set; }
        public string Number { get; set; }
        public string BagModel { get; set; }
        public Decimal Price { get; set; }

        public Int64 CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }

        public string Story { get; set; }

        public ResultStatus resultStatus { get; set; }
    }
}