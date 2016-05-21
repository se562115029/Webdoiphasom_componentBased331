using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;
using WebApplication3.Models.Repository;

namespace WebApplication3.Controllers
{
    public class PaymentController : Controller
    {
        private Payment payment = new Payment();
        IPaymentRepository repository;
        public PaymentController(IPaymentRepository paymentr)
        {
            this.repository = paymentr;

        }
        // GET: Payment
        public ActionResult Index()
        {
            var db = new EfDbContext();
            string currentUserId = User.Identity.GetUserId();


            var paymentCheckOrders = from o in db.payments
                                     where o.MemberID == currentUserId
                                     select o;
            return View(paymentCheckOrders);
        }
        [HttpPost]
        public ActionResult Index(Payment payment)
        {
            return RedirectToAction("Index");
        }

        public ActionResult IndexAdmin()
        {
            return View(repository.GetAllPayment());
        }
        [HttpPost]
        // GET: Payment/Details/5
        public ActionResult Details(Payment pay)
        {
            return RedirectToAction("IndexAdmin");
        }

        // GET: Payment/Create
        public ActionResult Create(string id)
        {
            Payment pay = repository.GetPaymentByID(id);

            return View(pay);
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(string orderid, FormCollection collection, HttpPostedFileBase file)
        {
            try
            {

                string Namepic = null;
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/paymentimage/" + ImageName);
                    file.SaveAs(physicalPath);
                    Namepic = "~/paymentimage/" + ImageName;
                }
                EfDbContext _context = new EfDbContext();
                int count = 0;
                foreach (Payment pay in _context.payments)
                {
                    count = int.Parse(pay.PaymentID);

                }
                count++;
                string currentUserId = User.Identity.GetUserId();


                var paymentCheckOrders = from o in _context.payments
                                         where o.MemberID == currentUserId
                                         select o;
                var item = paymentCheckOrders.ToList().First();
                string idorder = item.OrderID.ToString();
                Payment payment = new Payment();
                payment.PaymentID = count.ToString();
                payment.MemberID = User.Identity.GetUserId().ToString();
                payment.OrderID = idorder;
                payment.imageTranferReceipt = Namepic;
                repository.AddPayment(payment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(string id)
        {
            Payment pay = repository.GetPaymentByID(id);

            return View(pay);
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                string Namepic = null;
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/paymentimage/" + ImageName);
                    file.SaveAs(physicalPath);
                    Namepic = "~/paymentimage/" + ImageName;
                }
                EfDbContext _context = new EfDbContext();
                int count = 0;
                foreach (Payment pay in _context.payments)
                {
                    count = int.Parse(pay.PaymentID);

                }
                count++;
                string currentUserId = User.Identity.GetUserId();
                var paymentCheckOrders = from o in _context.payments
                                         where o.MemberID == currentUserId
                                         select o;
                var item = paymentCheckOrders.ToList().First();
                string idorder = item.OrderID.ToString();
                //var memebrid = collection["OrderID"];
                //var orderid = collection["MemberID"];
                Payment payment = new Payment();
                payment.PaymentID = id;
                payment.MemberID = User.Identity.GetUserId().ToString();
                payment.OrderID = idorder;
                payment.imageTranferReceipt = Namepic;
                repository.EditPayment(payment);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(string id)
        {
            Payment pay = repository.GetPaymentByID(id);

            return View(pay);
        }

        // POST: Payment/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                repository.DeletePayment(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
