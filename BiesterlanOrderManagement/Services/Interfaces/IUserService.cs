using BiesterlanOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.Services.Interfaces
{
    public interface IUserService
    {

         List<User> GetUsers(bool all);

        List<User> GetActiveUsers();

        List<Order> GetUserOrders(string username);

        List<UserOrderView> GetUserOrders(Guid? id);




    }
}
