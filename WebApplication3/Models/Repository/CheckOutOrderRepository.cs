using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Repository
{
    public class CheckOutOrderRepository : ICheckOutOrderRepository
    {
        EfDbContext _context = new EfDbContext();
        public void AddOrder(CheckOutOrder order)
        {
            _context.CheckOutOrders.Add(order);
            SaveCheckOutOrder();
        }

        public void DeleteOrder(string id)
        {
            CheckOutOrder order = _context.CheckOutOrders.Find(id);
            _context.CheckOutOrders.Remove(order);
            SaveCheckOutOrder();
        }

        public void EditOrder(CheckOutOrder order)
        {
            _context.Entry(order).State = EntityState.Modified;
            SaveCheckOutOrder();
        }

        public List<CheckOutOrder> GetAllOrder()
        {
            return _context.CheckOutOrders.ToList();
        }

        public CheckOutOrder GetOrderByID(string id)
        {
            return _context.CheckOutOrders.Find(id);
        }

        public void SaveCheckOutOrder()
        {
            _context.SaveChanges();
        }
    }
}