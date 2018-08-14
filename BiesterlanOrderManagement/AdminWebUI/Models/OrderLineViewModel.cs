using System;

namespace AdminWebUI.Models
{
    public class OrderLineViewModel
    {
        public Guid  Id { get; set; }

        
        public int Amount { get; set; } = 1;

        
        public string   Name { get; set; }

        public decimal SalesPrice { get; set; }


        public decimal OrderLineTotal
        {
            get { return (SalesPrice * Amount); }
        }

    }
}