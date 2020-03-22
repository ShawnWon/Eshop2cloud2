using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eshop2.Models;


namespace Eshop2.DB
{
    public class CartData
    {
        public static Cart GetCart(string username)
        {
            Cart cart = new Cart();

            using (var db = new ESDbContext())
            {
                if (db.Cart.Where(x => x.UserName == username).Any())
                    cart = db.Cart.Include("Items.product").Where(x => x.UserName == username).FirstOrDefault();
                else
                {
                    cart.UserName = username;
                    cart.Items = new List<Item>();
                    db.Cart.Add(cart);
                    db.SaveChanges();
                }
                
            }
            return cart;
        }

        public static void SaveCart(Cart cart)
        {
            

            using (var db = new ESDbContext())
            {
                
                Cart  c = db.Cart.Where(x => x.UserName == cart.UserName).FirstOrDefault();
                Item it = new Item();
                if (cart.Items != null)
                {
                    if (cart.Items.Sum(x => x.Quantity) != 0)
                    {
                        foreach (var item in cart.Items)
                        {
                            if (c.Items.Where(x => x.ProductId == item.ProductId).Any())
                                c.Items.Where(x => x.ProductId == item.ProductId).FirstOrDefault().Quantity = cart.Items.Where(x => x.ProductId == item.ProductId).FirstOrDefault().Quantity;
                            else
                            {
                                it.ProductId = item.ProductId;
                                it.Quantity = item.Quantity;
                                c.Items.Add(it);
                            }
                        }
                        
                    }
                    else
                    {
                        
                        foreach (var item in c.Items)
                        {
                            item.Quantity=0;

                        }
                        
                    
                    }
                    db.SaveChanges();
                    
                }
                
                
            }
            
        }
    }
}