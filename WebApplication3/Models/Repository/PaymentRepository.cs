using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        EfDbContext _context = new EfDbContext();
        public void AddPayment(Payment paymemt)
        {
            _context.payments.Add(paymemt);
            SavePayment();
        }

        public void DeletePayment(string id)
        {
            Payment Payment = _context.payments.Find(id);
            _context.payments.Remove(Payment);
            SavePayment();
        }

        public void EditPayment(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            SavePayment();
        }

        public List<Payment> GetAllPayment()
        {
            return _context.payments.ToList();
        }

        public Payment GetPaymentByID(string id)
        {
            return _context.payments.Find(id);
        }

        public void SavePayment()
        {
            _context.SaveChanges();
        }
    }
}
        