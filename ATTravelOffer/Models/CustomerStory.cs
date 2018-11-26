using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATTravelOffer.Models
{
    public class CustomerStory
    {
        public string PONumber { get; set; }
        public Int64 CustomerId { get; set; }
        public string Story { get; set; }

        public ResultStatus resultStatus { get; set; }
    }
}