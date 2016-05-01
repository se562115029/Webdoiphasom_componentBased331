﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Repository;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {

        ProductRepository repository = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {
            return View(repository.GetAllProduct());
        }


        [HttpPost]
        public ActionResult Index(Product p)
        {
            repository.AddProduct(p);
            //Test commit
            return RedirectToAction("Index");
        }




        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product product = new Product();

                    var id = collection["ID"];
                    var name = collection["Name"];
                    var price = collection["Price"];
                double ConvertNum = double.Parse(price);
                product.ID = id;
                product.Name = name;
                product.Price = ConvertNum;

                repository.AddProduct(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            Product product = repository.GetProductByID(id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Product product = new Product();

               
                var name = collection["Name"];
                var price = collection["Price"];
                double ConvertNum = double.Parse(price);
                product.ID = id;
                product.Name = name;
                product.Price = ConvertNum;
                repository.EditProduct(product);
                return RedirectToAction("Index");
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

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
