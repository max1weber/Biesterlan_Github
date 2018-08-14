using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminWebUI.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderLines = new List<OrderLineViewModel>();
        }
        public Guid Id { get; set; }
        public DateTime  CreateDateTime { get; set; }

        public string Name { get; set; }

        public List<OrderLineViewModel> OrderLines { get; set; }


        public decimal OrderTotal
        {
            get {
                var ordertotal = OrderLines.Sum(o => o.OrderLineTotal);
                return ordertotal;
                                  }
        }
    }
}