using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Entities
{
    public class Payment
    {
        public string PaymentID { get; set; }
        public string OrderID { get; set; }
        public string MemberID { get; set; }
        public string imageTranferReceipt { get; set; }
    }
}