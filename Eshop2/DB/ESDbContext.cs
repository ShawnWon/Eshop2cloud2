using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Eshop2.Models;

namespace Eshop2.DB
{
    public class ESDbContext:DbContext
    {
        
           
            public ESDbContext() : base("Server=den1.mssql7.gear.host;" + "Database=Eshop8; User Id=Eshop8; Password=Ilove1117@;")
            {
                System.Data.Entity.Database.SetInitializer(
                    new ESDbInitializer<ESDbContext>());

            }


            public DbSet<Cart> Cart { get; set; }

            public DbSet<Product> Product { get; set; }

            public DbSet<User> User { get; set; }

            public DbSet<ActCode> ActCode { get; set; }



        }
    
}