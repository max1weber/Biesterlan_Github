using BiesterlanOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.ViewModels
{
    public class OrdersViewModel
    {
        public UserViewModel User { get; set; }
        public List<Order> Orders { get; set; }

        public OrdersViewModel(UserViewModel userViewModel)
        {
            User = userViewModel;
            InitOrders();
        }

        private void InitOrders()
        {
           Orders = App.orderService.GetAllUserOrders(User.User.Name);
        }
    }
}
