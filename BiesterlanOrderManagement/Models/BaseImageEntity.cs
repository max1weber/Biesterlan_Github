using System;
using System.Collections.Generic;
using System.Text;

namespace BiesterlanOrders.Models
{
    public abstract class BaseImageEntity:BaseEntity
    {

        public byte[] Image { get; set; }
    }
}
