using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Entities
{
    public class Producttest
    {
        [Key]
        public string ProductOrderID { get; set; }
        public string MemberID { get; set; }
        public string ProductID { get; set; }
        public string DateOrder { get; set; }
        public string Adress { get; set; }
        public int Quanlity { get; set; }
        public double priceOfProduct { get; set; }
        public double CostFormMountain { get; set; }
        public double FreesTransfer { get; set; }
        public double TotalPayment { get; set; }
        public string ConfirmStatus { get; set; }
        public string PayMentStatus { get; set; }
        public string DeliveryStatus { get; set; }

    }
}