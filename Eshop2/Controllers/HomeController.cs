using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography; //implement hash password function
using System.Text;
using Eshop2.DB;
using Eshop2.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eshop2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            TempData["isAuth"] = true;
            return View();
        }

        public ActionResult  Logout()
        {
            //save cart info to database
            CartData.SaveCart((Cart)Session["cart"]);

           
                    Session.Clear();

                    return RedirectToAction("ProductList", "Product");
                

            }
            

       

        public ActionResult LoginCheckPassword(FormCollection form)
        {
            string username = form["Name"];
            string password = form["Password"];
            using (MD5 md5Hash = MD5.Create())
            {
                string hashedpassword = GetMd5Hash(md5Hash, password);


                if (hashedpassword == UserData.GetPassword(username))
                {
                    //when user submit the correct username and password , we create a new session.
                    
                    Session["username"] = username;
                    DateTime lastlogin = UserData.GetLastLogin(username);
                    DateTime logindate = DateTime.Today;
                    int bonus=0;
                    if (lastlogin!=logindate&&logindate<lastlogin.AddDays(7))  bonus = 50;
                    UserData.AddCoin(username,bonus);

                    Session["cart"] = CartData.GetCart(username);
                    Session["coin"] = UserData.GetCoinNum(username);
                    UserData.UpdateLastLogin(username);
                    return RedirectToAction("ProductList", "Product");
                }
            }
            TempData["isAuth"] = false;
            return View("Login");

        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public ActionResult Register()
        {


            return View();
        }

        public ActionResult CheckUsernameRule(string Name)
        {
            if (Name == "god" ||
                Name == "f**k" ||
                Name == "shit")
            {
                return Json(false);
            }
            return Json(true);
        }

        public ActionResult ValiEmail(string EmailAdd)
        {
            List<string> EMList = UserData.GetAllEmail();
            bool exist = false;

            for (int i = 0; i < EMList.Count; i++)
            {

                if (EMList[i] == EmailAdd) exist = true;
            }

            if (exist) return Json(false);
            return Json(true);
        }

  


        public bool CheckUserName(string username)
        {
            List<string> UserNList = UserData.GetAllUserN();
            bool exist = false;

            for (int i = 0; i < UserNList.Count; i++)
            {

                if (UserNList[i] == username) exist = true;
            }


            return exist;
        }

        public ActionResult RegNewUser(FormCollection form)
        {
            string username = form["Name"];
            string password = form["Password"];
            string ConPw = form["Confirm_password"];
            string EM = form["EmailAdd"];




            if (CheckUserName(username))
            {

                return RedirectToAction("Regfail", "Home");
            }
            else
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hashedpassword = GetMd5Hash(md5Hash, password);

                    UserData.AddNewUser(username, hashedpassword, hashedpassword, EM);
                }
                return RedirectToAction("RegSuc", "Home");
            }


        }

        public ActionResult RegSuc()
        {
            return View();
        }

        public ActionResult RegFail()
        {
            return View();
        }

        public ActionResult TnC()
        {
            return File("~/Content/images/TnC.pdf", "application/pdf");
        }


        }







}

