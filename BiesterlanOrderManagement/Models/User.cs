using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BiesterlanOrders.Models
{
    public class User:BaseImageEntity
    {

        public User()
        {
            Orders = new List<Order>();
            ID = Guid.NewGuid();
            Name = "Username";
        }


        


        [Required]
        public bool Active { get; set; } = false;

        public virtual List<Order> Orders { get; set; }


       
        [MaxLength(250)]
        public string ImageName { get; set; }


       

    }
}
