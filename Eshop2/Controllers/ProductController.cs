using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop2.Models;
using Eshop2.DB;
using System.Net.Http;

namespace Eshop2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ProductList(string searchStr)
        {
            List<Product> Plist;
            Plist = ProductData.GetAllProducts();
            List<Product> Rlist = new List<Product> { };
            bool match = false;
            Session["page"] = "productlist";

            if (Request.IsAuthenticated)
            {
                string username = User.Identity.Name;
                username = "JonSnow";
                Cart cart = CartData.GetCart(username);
                Session["cart"]= cart;
                Session["coin"] = UserData.GetCoinNum(username);
                if (cart.Items != null)
                    ViewData["cartcount"] = cart.Items.Sum(x => x.Quantity);
                else
                    ViewData["cartcount"] = 0;

                //int UserPre = UserData.GetPreference((string)Session["username"]); */
                ViewBag.product = ProductData.GetProductsByCat(1);

            }
            
            if (searchStr == null)
            {
                searchStr = "";
                ViewBag.Rlist = Plist;
            }
            else
            {
                foreach (Product Pro in Plist)
                {
                    bool fit = false;
                    if (Found(Pro.ProductName, searchStr).fit)
                    {
                        fit = true;
                        Pro.ProductName = Found(Pro.ProductName, searchStr).str;
                    }
                    if (Found(Pro.ProductDes, searchStr).fit)
                    {
                        fit = true;
                        //Pro.ProductDes = Found(Pro.ProductDes, searchStr).str;
                    }

                    if (fit) { match = true; Rlist.Add(Pro); }
                }
                ViewBag.Rlist = Rlist;
            }


            ViewData["searchStr"] = searchStr;
            ViewData["match"] = match;

            
            return View();
        }

        public searchResult Found(string ba, string ta)
        {

            string s = ba;
            int index = ba.IndexOf(ta, StringComparison.CurrentCultureIgnoreCase);
            if (index != -1)
            {

                s = ba.Substring(0, index) + "<span class='font-red'>" + ba.Substring(index, ta.Length) + "</span>" + ba.Substring(index + ta.Length);
            }

            return new searchResult { fit = (index != -1), str = s };

        }

        [HttpPost]
        public JsonResult ClickAddtoCart(int Id)
        {
            Cart cart = (Cart)Session["cart"];
            bool exist=false;
            if(cart.Items!=null)
                exist = cart.Items.Where(x=>x.ProductId==Id).Any();

            if (exist == false)
            {
                Product p = new Product();
                p = ProductData.GetProductsById(Id);

                
                Item item = new Item(Id,1,p);
                
                    cart.Items.Add(item);
                
                
            }
            else
            {
                cart.Items.Where(x => x.ProductId == Id).FirstOrDefault().Quantity += 1;
            
            }

            ViewData["cartcount"] = cart.Items.Sum(x=>x.Quantity);
            Session["cart"] = cart;

            object new_q = new { quant = cart.Items.Sum(x=>x.Quantity) };
            return Json(new_q, JsonRequestBehavior.AllowGet);

        }

    }
}