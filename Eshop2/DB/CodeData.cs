using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eshop2.Models;

namespace Eshop2.DB
{
    public class CodeData
    {
        public static List<ActCode> GetCodebyUserId(int uid)
        {
            List<ActCode> codelist = new List<ActCode>();
            using (var db = new ESDbContext())
            {
                codelist = db.ActCode.Include("product").Where(x => x.UserId == uid).ToList();
            
            }

            return codelist;
        
        }

        public static void AddCode(ActCode code)
        {
            
            using (var db = new ESDbContext())
            {
                db.ActCode.Add(code);
                db.SaveChanges();

            }

        }
    }
}