using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.Models
{
    public class Order:BaseEntity
    {
        public Order()
        {
            Orderlines = new HashSet<Orderline>();
            Name = "OrderItem";
        }



        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        [Required]
        public virtual User User { get; set; }

        public virtual Guid UserId { get; set; }

        public virtual HashSet<Orderline> Orderlines { get; set; }

        public decimal OrderTotal()
        {

            decimal ordertotal = 0;

            foreach (Orderline line in Orderlines)
            {
                ordertotal += line.OrderLineTotal;
            }

            return ordertotal;
        }
    }
}
