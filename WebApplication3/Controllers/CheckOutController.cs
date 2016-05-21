using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;
using WebApplication3.Models.Repository;
using Microsoft.AspNet.Identity;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CheckOutController : Controller
    {
        EfDbContext _context = new EfDbContext();
        private CheckOutOrder Corder = new CheckOutOrder();
        ICheckOutOrderRepository repository;
        public CheckOutController(ICheckOutOrderRepository checkout)
        {
            this.repository = checkout;
        }
        ICheckOutOrderRepository checkoutrepo = new CheckOutOrderRepository();
      

        // GET: CheckOut
        public ActionResult Index()
        { var db = new EfDbContext();
            string currentUserId = User.Identity.GetUserId();
         
           
            var CheckOrders = from o in db.CheckOutOrders
                                  where o.MemberID == currentUserId
                              select o;
            
            return View(CheckOrders);
        }
        [HttpPost]
        public ActionResult Index(CheckOutOrder check)
        {

            return RedirectToAction("Index");
        }
        public ActionResult IndexAdmin()
        {
            return View(repository.GetAllOrder());
        }
        [HttpPost]
        public ActionResult IndexAdmin(CheckOutOrder check)
        {
            
            return RedirectToAction("IndexAdmin");

        }
        // GET: CheckOut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckOut/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckOut/Edit/5
        public ActionResult Edit(string id)
        {
            //EfDbContext _context = new EfDbContext();
            //CheckOutOrder order = _context.CheckOutOrders.Find(id);
            CheckOutOrder order = repository.GetOrderByID(id);
            
            return View(order);
        }

        // POST: CheckOut/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CheckOutOrder checkoutobj = new CheckOutOrder();
                EfDbContext _context = new EfDbContext();
                int count = 0;
                foreach (CheckOutOrder ck in _context.CheckOutOrders)
                {
                    count = int.Parse(ck.CheckOutOrderID);

                }
                count++;
                var memberID = collection["MemberID"];
                var productID = collection["ProductID"];
                
                var address = collection["Adress"];
                var priceproduct = collection["priceOfProduct"];
                var costFormMountain = collection["CostFormMountain"];
                var Frees = collection["FreesTransfer"];
                var totalprice = collection["TotalPayment"];
                var confirmorder = collection["ConfirmStatus"];
                var paymentStatus = collection["PayMentStatus"];
                var delivery = collection["DeliveryStatus"];
                checkoutobj.CheckOutOrderID = id;
                checkoutobj.MemberID = memberID;
                checkoutobj.DateOrder = DateTime.Now.ToString() ;
                checkoutobj.Adress = address;
                checkoutobj.priceOfProduct = priceproduct;
                checkoutobj.CostFormMountain = costFormMountain;
                checkoutobj.FreesTransfer = Frees;
                checkoutobj.TotalPayment = totalprice;
                checkoutobj.ConfirmStatus = confirmorder;
                checkoutobj.PayMentStatus = paymentStatus;
                checkoutobj.DeliveryStatus = delivery;
                checkoutobj.ProductID = productID;
                repository.EditOrder(checkoutobj);


                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }
        // GET: CheckOut/Delete/5
        public ActionResult Delete(string id)
        {
            CheckOutOrder ck = repository.GetOrderByID(id);
            return View(ck);
        }
        // POST: CheckOut/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                repository.DeleteOrder(id);

                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }
    }
}
