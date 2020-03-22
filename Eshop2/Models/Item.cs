using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product product { get; set; }

        public Item(int pi, int q, Product p)
        {
            ProductId = pi;
            Quantity = q;
            product = p;
        
        }
        public Item()
        { 
        }
    }
}