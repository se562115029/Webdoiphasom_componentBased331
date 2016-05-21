using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models.Repository
{
    public interface ICheckOutOrderRepository
    {
        void AddOrder(CheckOutOrder  order);
        void DeleteOrder(string id);
        void EditOrder(CheckOutOrder order);
        List<CheckOutOrder> GetAllOrder();
        CheckOutOrder GetOrderByID(string id);
        void SaveCheckOutOrder();

    }
}