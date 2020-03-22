using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop2.DB;
using System.Threading.Tasks;
using System.Net.Http;

namespace Eshop2.Controllers
{
    public class PrayController : Controller
    {
        // GET: Pray
        public ActionResult PrayPage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PraySubmit(int id)
        {
            string username = (string)Session["username"];
            //UserData.UpdatePref(username,id);
            UserData.UpdateClick(username, id);
            
            int ccount = UserData.GetCoinNum(username);
            ccount -= 1;
            UserData.UpdateCoin(username,ccount);
            Session["coin"] = ccount;
            object new_amount = new { coincount = ccount };

            return Json(new_amount, JsonRequestBehavior.AllowGet);
        }

       
    }
}