using BiesterlanOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.Services.Interfaces
{
    public interface IOrderService
    {
        IQueryable<Order> GetAllOrders();

        List<Order> GetAllUserOrders(string username);

        Order CreateOrder(string username);

        Order AddOrderline(Order order, Orderline line);

        int Save();

        int SaveOrders(Order ordertosave);



    }
}
