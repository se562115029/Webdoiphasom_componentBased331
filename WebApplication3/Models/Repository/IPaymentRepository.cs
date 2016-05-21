using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Repository
{
  public interface IPaymentRepository
    {
        void AddPayment(Payment paymemt);
        void DeletePayment(string id);
        void EditPayment(Payment payment);
        List<Payment> GetAllPayment();
        Payment GetPaymentByID(string id);
        void SavePayment();
    }
}