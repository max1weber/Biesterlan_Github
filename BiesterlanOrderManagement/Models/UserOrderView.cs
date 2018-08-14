using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiesterlanOrders.Models
{
    public class UserOrderView
    {

        public Guid UserID { get; set; }
        public string Name { get; set; }

        public Guid OrderID { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string ArticleName { get; set; }

        public int Amount { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal LineTotal { get; set; }
     

    }
}
