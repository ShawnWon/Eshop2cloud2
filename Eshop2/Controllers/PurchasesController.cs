using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop2.Models;
using Eshop2.DB;
using Eshop2.Filter;

namespace Eshop2.Controllers
{
    [Authorize]
    public class PurchasesController : Controller
    {
        public ActionResult MyPurchases()
        {
            List<ActCode> LAbU = new List<ActCode>();
            List<Product> LP = new List<Product>();
            int userid = UserData.GetId((string)Session["username"]);
            Session["page"] = "purchases";



            LAbU = CodeData.GetCodebyUserId(userid);
            LP = ProductData.GetAllProducts();

            ViewData["labu"] = LAbU;
            ViewBag.RList = LP;



            return View();
        }
    }
}