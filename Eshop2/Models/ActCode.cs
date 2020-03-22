using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop2.Models
{
    public class ActCode
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }

     
        public virtual Product product { get; set; }

        public ActCode(int userN, int proN, Guid actC, DateTime ordD)
        {
            UserId = userN;
            ProductId = proN;
            Code = actC;
            OrderDate = ordD;
        }

        public ActCode()
        { }
    }
}