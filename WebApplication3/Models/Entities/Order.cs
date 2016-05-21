using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Entities
{
    public class Order
    {
        public string orderID { get; set; }
        public string MemberID { get; set; }
        public string PaymentID { get; set; }
        public string ProductID { get; set; }
        public string DateOrder { get; set; }
        public string Productprice { get; set; }
        public string Addresss { get; set; }
        public string Costformountain { get; set; }
        public string FreesToHome { get; set; }
        public string Totalpayment { get; set; }

    }
}