using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop2.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        
        
        public virtual ICollection<Item> Items { get; set; }

    }
}