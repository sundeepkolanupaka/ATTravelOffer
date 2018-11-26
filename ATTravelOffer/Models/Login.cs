using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATTravelOffer.Models
{
    public class Login
    {
        public string LoginId { get; set; }
        public string Password { get; set; }

        public ResultStatus ResultStatus { get; set; }
    }
}