using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebUI.Models
{
    public class ProductResultModel
    {

       
        public string Name { get; set; }
        public int Amount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
