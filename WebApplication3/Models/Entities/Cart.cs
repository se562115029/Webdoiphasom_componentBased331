using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Entities
{
    public class Cart
    {
        private Product pro = new Product();

        private int quantity;

        public int Quantity
        {
            get
            {
                return Quantity1;
            }

            set
            {
                Quantity1 = value;
            }
        }

        public Product Pro
        {
            get
            {
                return pro;
            }

            set
            {
                pro = value;
            }
        }

        public int Quantity1
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

       
        public Cart() { }
        public Cart(Product pr, int quantity)
        {
            this.Pro = pr;
            this.Quantity = quantity;
        }
    }
}
