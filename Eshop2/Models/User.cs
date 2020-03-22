using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//using this to inplement validation
using System.Web.Mvc;//also using this to inplement validation

namespace Eshop2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Remote("CheckUsernameRule", "Home", HttpMethod = "POST",
            ErrorMessage = "Username is not allowed")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Username can only consist of alphabets")]
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string Name { get; set; }

        [StringLength(32, MinimumLength = 6, ErrorMessage = "Password length incorrect.")]
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare(
            "Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Remote("ValiEmail", "Home", HttpMethod = "POST",
            ErrorMessage = "Email address already registered")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAdd { get; set; }

        public int coin { get; set; }
        public DateTime lastlogin { get; set; }
        public int Preference { get; set; }
        public string ClickHist { get; set; }

        public User(string username, string password, string ConPw, string Email)
        {

            Name = username;
            Password = password;
            ConfirmPassword = ConPw;
            EmailAdd = Email;
            coin = 50;
            lastlogin = DateTime.Today.Date.AddDays(-1);
            Preference = 0;
            ClickHist = "0,0,0,0,0,0,0,0";
            

        }

        public User()
        { }
    }


}