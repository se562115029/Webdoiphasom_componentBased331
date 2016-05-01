using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models.EF;

namespace WebApplication3.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        EfDbContext context = new EfDbContext();

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            SaveProduct();
        }

        public void DeleteProduct(string id)
        {
            Product product = context.Products.Find(id);
            context.Products.Remove(product);
            SaveProduct();
        }

        public void EditProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            SaveProduct();
        }

        public List<Product> GetAllProduct()
        {
            return context.Products.ToList();
        }

        public Product GetProductByID(string id)
        {
            return context.Products.Find(id);
        }

        public void SaveProduct()
        {
            context.SaveChanges();
        }
    }
}