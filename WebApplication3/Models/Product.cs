using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Product
    {
     
        public string ID { get; set; }
        public string Name { get; set; }
        public double PriceRetail { get; set; }
        public double PriceWholesale { get; set; }
        public string description { get; set; }
        public string image { get; set; }

    }
}