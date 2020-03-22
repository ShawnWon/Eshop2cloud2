using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop2.Models
{
    public class Product
    {
       
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string ProductDes { get; set; }
            public int Price { get; set; }
            public string Imgaddress { get; set; }
            public int Cat { get; set; }//1Spirit,2Material,3Relation,4Personel,5Others

        public Product(string name, string description, int price, string imageadd, int cat)
        {

            ProductName = name;
            ProductDes = description;
            Price = price;
            Imgaddress = imageadd;
            Cat = cat;
        }

        public Product()
        { 
        }

    }

    public class searchResult
    {
        public string str { get; set; }
        public bool fit { get; set; }
    }
}