using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eshop2.Models;

namespace Eshop2.DB
{
    public class UserData
    {
        public static int GetPreference(string username)
        {
            int Pre=0;
            using (var db = new ESDbContext())
            {
                if (db.User.Where(x => x.Name == username).Any())
                    Pre = db.User.Where(x => x.Name == username).FirstOrDefault().Preference;

            }
            return Pre;
        
        }
        public static DateTime GetLastLogin(string username)
        {
            DateTime dt=DateTime.Today.Date.AddDays(-30);

            using (var db = new ESDbContext())
            {
                if (db.User.Where(x => x.Name == username).Any())
                    dt = db.User.Where(x => x.Name == username).FirstOrDefault().lastlogin;

            }
            return dt;
        }

        public static string GetPassword(string username)
        {
            string pw = "";

            using (var db=new ESDbContext())
            {
                if(db.User.Where(x=>x.Name==username).Any())
                pw = db.User.Where(x => x.Name == username).FirstOrDefault().Password;
           
            }
            return pw;
        }

        public static int GetCoinNum(string username)
        {
             int cn = 0;

            using (var db = new ESDbContext())
            {
                if (db.User.Where(x => x.Name == username).Any())
                    cn = db.User.Where(x => x.Name == username).FirstOrDefault().coin;

            }
            return cn;
        }

        public static int GetId(string username)
        {
            int id=0;

            using (var db = new ESDbContext())
            {
                if (db.User.Where(x => x.Name == username).Any())
                    id = db.User.Where(x => x.Name == username).FirstOrDefault().Id;

            }
            return id;
        }

        public static List<string> GetAllUserN()
        {
            List<string> UNList = new List<string>();

            using (var db=new ESDbContext())
            {
                UNList = db.User.Select(x=>x.Name).ToList();

            }
            return UNList;
        }

        public static List<string> GetAllEmail()
        {
            List<string> EMList = new List<string>();

            using (var db=new ESDbContext())
            {
                EMList = db.User.Select(x => x.EmailAdd).ToList();
            }
            return EMList;
        }

        public static string GetClickhist(string username)
        {
            string Chist;
            
            using (var db = new ESDbContext())
            {
                User u= db.User.Where(x => x.Name == username).FirstOrDefault();
                Chist = u.ClickHist;
            }
            return Chist;
        }

        public static void AddNewUser(string UN, string PW, string CPW, string EM)
        {
        

            using (var db = new ESDbContext())
            {
                User newuser = new User(UN, PW, CPW, EM);
                db.User.Add(newuser);
                db.SaveChanges();
            }

        }
        public static void AddCoin(string UN, int num)
        {


            using (var db = new ESDbContext())
            {
                
                User u=db.User.Where(x=>x.Name==UN).FirstOrDefault();
                u.coin += num;
                db.SaveChanges();
            }

        }



        public static void UpdateCoin(string UN, int CN)
        {


            using (var db = new ESDbContext())
            {
                User u = db.User.Where(x=> x.Name==UN).FirstOrDefault();
                u.coin = CN;
                db.SaveChanges();
            }

        }

        public static void UpdatePref(string UN, int Pre)
        {


            using (var db = new ESDbContext())
            {
                User u = db.User.Where(x => x.Name == UN).FirstOrDefault();
                u.Preference = Pre;
                db.SaveChanges();
            }

        }

        public static void UpdateClick(string UN, int wishId)
        {


            using (var db = new ESDbContext())
            {
                User u = db.User.Where(x => x.Name == UN).FirstOrDefault();
                
                string s = u.ClickHist;
                var numbers = s.Split(',').Select(Int32.Parse).ToList();
                numbers[wishId-1] += 1; //wish button indexed from 1 to 8, list indexed from 0 to 7
                var result = string.Join(", ", numbers);
                u.ClickHist = result;

                //cloud edition update preference directly without talk to python model
                u.Preference = wishId;

                db.SaveChanges();
            }

        }

        public static void UpdateLastLogin(string UN)
        {


            using (var db = new ESDbContext())
            {
                User u = db.User.Where(x => x.Name == UN).FirstOrDefault();
                u.lastlogin = DateTime.Today;
                db.SaveChanges();
            }

        }
    }
}