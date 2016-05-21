using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Entities
{
    public class CheckOutOrder
    {

        public string CheckOutOrderID { get; set; }
        public string MemberID { get; set; }
        public string ProductID { get; set; }
        public string DateOrder { get; set; }
        public string Adress { get; set; }
        public string priceOfProduct { get; set; }
        public string CostFormMountain { get; set; }
        public string FreesTransfer { get; set; }
        public string TotalPayment { get; set; }
        public string ConfirmStatus { get; set; }
        public string PayMentStatus { get; set; }
        public string DeliveryStatus { get; set; }

    }
}