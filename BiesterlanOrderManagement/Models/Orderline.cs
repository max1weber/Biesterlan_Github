using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiesterlanOrders.Models
{
    public class Orderline:BaseEntity
    {

       

        [System.ComponentModel.DataAnnotations.Required]
        public virtual Order Order { get; set; }

        [Required]
        public int Amount { get; set; } = 1;

       

        [Required]
       // [Index("IX_ArticleId", IsUnique =false)]
        public Guid ArticleID { get; set; }

        [Required]
        public decimal SalesPrice { get; set; }


        public decimal OrderLineTotal {
            get { return (SalesPrice * Amount); }
        }

    }
}
