using BiesterlanOrders.Models;
using BiesterlanOrders.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.Services.Implementation
{
    public class OrderService : BaseService,IOrderService
    {
        IUserService _userservice = new UserService();
        
        private Order _currentOrder;
        public Order AddOrderline(Order order, Orderline line)
        {
            _currentOrder.Orderlines.Add(line);
            return _currentOrder;
        }

        public Order CreateOrder(string username)
        {
            Order order = new Order();
            User user= _userservice.GetActiveUsers().FirstOrDefault(p => p.Name.Equals(username.Trim(), StringComparison.InvariantCultureIgnoreCase));
            _currentOrder = order;
            _currentOrder.User = user;
            return order;
            
        }

        public IQueryable<Order> GetAllOrders()
        {
            return db.Orders.OrderByDescending(o => o.CreateDateTime).AsQueryable();
        }

        public List<Order> GetAllUserOrders(string username)
        {
           return GetAllOrders().Where(p => p.User.Name.Equals(username)).ToList();
        }

        public int SaveOrders(Order ordertosave)
        {
            db.Database.BeginTransaction();
            db.Orders.Add(ordertosave);
            
            foreach (var lineitem in ordertosave.Orderlines)
            {
                db.Orderlines.Add(lineitem);
            }
            var result =Save();
            db.Database.CommitTransaction();
            return result;
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        int IOrderService.Save()
        {
            return Save();
        }

        
    }
}
