using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eshop2.Models;

namespace Eshop2.DB
{
    public class ProductData
    {

        public static List<Product> GetAllProducts()
        {
            List<Product> PList = new List<Product>();
            using (var db=new ESDbContext())
            {

                PList = db.Product.ToList();
                
            }
            return PList;
        }

        public static Product GetProductsById(int ProductId)
        {
            Product p = new Product();
            using (var db = new ESDbContext())
            {
                p = db.Product.Where(x => x.Id == ProductId).FirstOrDefault();
                
            }
            return p;
        }

        public static Product GetProductsByCat(int cat)
        {
            Product p = new Product();
            using (var db = new ESDbContext())
            {
                var rand = new Random();
                List<Product> Lp = db.Product.Where(x => x.Cat == cat).ToList();
                p = Lp[rand.Next(Lp.Count)];

            }
            return p;
        }

    }

}