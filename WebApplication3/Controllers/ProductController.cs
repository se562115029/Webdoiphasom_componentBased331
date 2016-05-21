using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;
using WebApplication3.Models.Repository;
using Microsoft.AspNet.Identity;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {

        private Product product = new Product();
        IProductRepository repository;
        public ProductController(IProductRepository product)
        {
            this.repository = product;
        }
        ICheckOutOrderRepository checkoutrepo = new CheckOutOrderRepository();


        // GET: Product
     
        public ActionResult IndexAdmin()
        {
            return View(repository.GetAllProduct());
        }

      
        [HttpPost]
        public ActionResult IndexAdmin(Product p)
        {
     
            //Test commit
            return RedirectToAction("IndexAdmin");
        }



        // GET: Product
        EfDbContext _context = new EfDbContext();
        [Authorize(Roles = "Retail")]
        public ActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        [Authorize(Roles = "Retail")]
        [HttpPost]

        public ActionResult Index(Product p)
        {
            repository.AddProduct(p);
            //Test commit
            return RedirectToAction("Index");

        }
         [Authorize(Roles = "Wholesale")]
        public ActionResult IndexWholesale()
        {
            return View(_context.Products.ToList());
        }

        [Authorize(Roles = "Wholesale")]
        [HttpPost]
        public ActionResult IndexWholesale(Product p)
        {
            repository.AddProduct(p);
            //Test commit
            return RedirectToAction("Index");
        }



        private int isExisting(string id)
        {
            List<Cart> items = (List<Cart>)Session["cartitem"];
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Pro.ID == id)
                {
                    return i;
                }
            }
            return -1;
        }
       
        public ActionResult DeleteProductInCart(string id)
        {
            int index = isExisting(id);
            List<Cart> items = (List<Cart>)Session["cartitem"];
            items.RemoveAt(index);
            Session["cartitem"] = items;
            return View("AddToSession");
        }


        public ActionResult AddToSession(string id)
        {

            if (Session["cartitem"] == null)
            {

                List<Cart> items = new List<Cart>();
                items.Add(new Cart(_context.Products.Find(id), 1));
                Session["cartitem"] = items;
            }
            else
            {
                List<Cart> items = (List<Cart>)Session["cartitem"];
                int index = isExisting(id);
                if (index == -1)
                {
                    items.Add(new Cart(_context.Products.Find(id), 1));
                }
                else
                {
                    items[index].Quantity++;

                }
                Session["cartitem"] = items;
            }

            return View("AddToSession");
        }
        public ActionResult AddToSessionWholesales(string id)
        {

            if (Session["cartitem"] == null)
            {

                List<Cart> items = new List<Cart>();
                items.Add(new Cart(_context.Products.Find(id), 1));
                Session["cartitem"] = items;
            }
            else
            {
                List<Cart> items = (List<Cart>)Session["cartitem"];
                int index = isExisting(id);
                if (index == -1)
                {
                    items.Add(new Cart(_context.Products.Find(id), 1));
                }
                else
                {
                    items[index].Quantity++;

                }
                Session["cartitem"] = items;
            }

            return View("AddToSession");
        }
        public ActionResult AddOrder()
        {
            return View("AddOrder");
        }
        [HttpPost]
        public ActionResult SaveOrder(FormCollection collection)
        {
            
            ApplicationDbContext context = new ApplicationDbContext();
            
            double costFormDoi = 0;
            String Choice = Request.Form["CostFormDoi"].ToString();
            if (Choice== "Share with other")
            {
                costFormDoi = -1;
            }if(Choice== "transferred immediately")
            {
                costFormDoi = 800;
            }if(Choice== "Free")
            {
                costFormDoi = 0;
            }

            EfDbContext _context = new EfDbContext();
            int count = 0;
            foreach (CheckOutOrder check in _context.CheckOutOrders)
            {
                count = int.Parse(check.CheckOutOrderID);

            }
            count++;
            
        
         // string userid = Session["UserID"].ToString();
         //string total = Session["Total"].ToString();
            CheckOutOrder checkorder = new CheckOutOrder();
            ICheckOutOrderRepository checkrepo = new CheckOutOrderRepository();
            List<Cart> items = (List<Cart>)Session["cartitem"];
            double totalpriceproduct = 0;
            for(int i = 0; i < items.Count; i++)
            {
                totalpriceproduct +=items[i].Pro.PriceRetail;
            }
          
                checkorder.CheckOutOrderID = count.ToString();
                checkorder.DateOrder = DateTime.Now.ToString();
                checkorder.Adress = collection["Adress"];
                checkorder.MemberID = User.Identity.GetUserId().ToString();
                checkorder.ConfirmStatus = "Wait";
                checkorder.CostFormMountain = costFormDoi.ToString();
                checkorder.ProductID = "-1";
                checkorder.priceOfProduct = "-1";
                checkorder.FreesTransfer = "0";
                checkorder.PayMentStatus = "Wait";
                checkorder.TotalPayment = totalpriceproduct.ToString();
                checkorder.DeliveryStatus = "Wait";
                checkoutrepo.AddOrder(checkorder);

          


            //List<Cart> items = (List<Cart>)Session["cartitem"];
            //for (int i = 0; i < items.Count; i++)
            //{
            //    CheckOutOrder checkout = new CheckOutOrder();
            //    checkout.CheckOutOrderID = count.ToString();
            //    checkout.MemberID = memberid.ToString();
            //    checkout.ProductID = items[i].Pro.ID;
            //    checkout.Adress = address;
            //    checkout.DateOrder = DateTime.ToString();
            //    checkout.CostFormMountain = costFormMountain.ToString();
            //    checkout.priceOfProduct = items[i].Pro.PriceRetail.ToString();
            //    checkout.TotalPayment = totalpayment.ToString();
            //    checkout.FreesTransfer = "0";
            //checkout.ConfirmStatus = "Wait";
            //    checkout.PayMentStatus = "Wait";
            //    checkout.DeliveryStatus ="Wait";
            //    checkoutrepo.AddOrder(checkout);
            //    return View("AddOrder");
            //}


            return View("~/Views/Product/Thank.cshtml");
            Session.Remove("cartitem");
            
        }
        public ActionResult Thank(Product p)
        {

            //Test commit
            return View();
        }

       
        public ActionResult ViewOrder()
        {
            return View(checkoutrepo.GetAllOrder());
        }
     
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
       
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                string Namepic = null;
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/images/" + ImageName);
                     file.SaveAs(physicalPath);
                    Namepic = "~/images/" + ImageName;
                }
                Product product = new Product();
                EfDbContext _context = new EfDbContext();
                int count = 0;
                foreach (Product pro in _context.Products)
                {
                    count = int.Parse(pro.ID);

                }
                count++;

                var name = collection["Name"];
                var description = collection["description"];
                var retailprice = collection["PriceRetail"];
                var wholesalseprice = collection["PriceWholesale"];

                double ConvertNumretailPrice = double.Parse(retailprice);
                double ConvertNumwholesalseprice = double.Parse(wholesalseprice);
                product.ID = count.ToString();
                product.Name = name;
                product.description = description;
                product.PriceRetail = ConvertNumretailPrice;
                product.PriceWholesale = ConvertNumwholesalseprice;
                product.image = Namepic;
                repository.AddProduct(product);
                return RedirectToAction("IndexAdmin");

            }
            catch
            {
                return View();
            }
        }
     
        //// GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            Product product = repository.GetProductByID(id);
            return View(product);
        }
      
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                string Namepic = null;
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/images/" + ImageName);
                    file.SaveAs(physicalPath);
                    Namepic = "~/images/" + ImageName;
                }
                //Product product = new Product();
                //EfDbContext _context = new EfDbContext();
                //int count = 0;
                //foreach (Product pro in _context.Products)
                //{
                //    count = int.Parse(pro.ID);

                //}
                //count++;

                var name = collection["Name"];
                var description = collection["description"];
                var retailprice = collection["PriceRetail"];
                var wholesalseprice = collection["PriceWholesale"];

                double ConvertNumretailPrice = double.Parse(retailprice);
                double ConvertNumwholesalseprice = double.Parse(wholesalseprice);
                product.ID = id;
                product.Name = name;
                product.description = description;
                product.PriceRetail = ConvertNumretailPrice;
                product.PriceWholesale = ConvertNumwholesalseprice;
                product.image = Namepic;
                repository.EditProduct(product);
                return RedirectToAction("IndexAdmin");

            }
            catch
            {
                return View();
            }
        }
       
        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            Product product = repository.GetProductByID(id);
            return View(product);
        }

        //POST: Product/Delete/5
      
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.DeleteProduct(id);
                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }

        
    }
}