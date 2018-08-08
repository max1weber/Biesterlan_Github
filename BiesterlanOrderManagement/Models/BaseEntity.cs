using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiesterlanOrders.Models
{
    public abstract class BaseEntity
    {

        [System.ComponentModel.DataAnnotations.Required]
        [Key]
        public Guid ID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
