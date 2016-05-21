using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("EfDbContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<CheckOutOrder> CheckOutOrders { get; set; }
        public DbSet<Producttest> Prducttests { get; set; }
        public object Orders { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}