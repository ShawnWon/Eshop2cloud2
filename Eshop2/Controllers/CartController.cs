using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop2.DB;
using Eshop2.Filter;
using Eshop2.Models;


namespace Eshop2.Controllers
{
    
    [Authorize]
    public class CartController : Controller
    {

        public ActionResult ViewCart()
        {


            List<Item> itemlist = new List<Item>();
            Cart cart = (Cart)Session["cart"];
            Session["page"] = "cart";
            int amount = 0;
            foreach (var item in cart.Items)
            {

                itemlist.Add(item);
                amount = amount + item.product.Price * item.Quantity;
            }



            ViewBag.cart = itemlist;
            ViewData["cartamount"] = amount;





            return View();
        }


        
        public ActionResult Checkout()
        {
            string username = (string)Session["username"];
            int coin = (int)Session["coin"];
            Cart cart = (Cart)Session["cart"];
            if ((int)Session["coin"] < cart.Items.Sum(x=>x.Quantity*x.product.Price))
                return RedirectToAction("ViewCart","Cart");
            else
            {



                foreach (Item it in cart.Items)
                {


                    for (int i = it.Quantity; i > 0; i--)
                    {
                        Guid GI = Guid.NewGuid();
                        int userid = UserData.GetId(username);
                        int productid = it.ProductId;
                        DateTime od = DateTime.Today;

                        ActCode newcode = new ActCode(userid, productid, GI, od);
                        CodeData.AddCode(newcode);
                        coin-=it.product.Price;

                        cart.Items.Where(x => x.ProductId == it.ProductId).FirstOrDefault().Quantity -= 1;
                        
                    }
                    
                    UserData.UpdateCoin(username, coin);
                    Session["coin"]= coin;
                }

            }

            return RedirectToAction("MyPurchases", "Purchases");
        }

        [HttpPost]
        public JsonResult ChangeCart(int pi, int qu)
        {
            Cart cart = (Cart)Session["cart"];

            cart.Items.Where(x => x.ProductId == pi).FirstOrDefault().Quantity = qu;

            double amount = 0;
            
            foreach (var item in cart.Items)
            {
                Product p = ProductData.GetProductsById(item.ProductId);
                amount = amount + p.Price * item.Quantity;
            }

            object new_amount = new { amt =Math.Round(amount,2) };
            
            return Json(new_amount, JsonRequestBehavior.AllowGet); 
        }
    }
}