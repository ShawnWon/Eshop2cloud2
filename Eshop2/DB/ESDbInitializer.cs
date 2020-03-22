using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Eshop2.Models;

namespace Eshop2.DB
{
    public class ESDbInitializer<T>: DropCreateDatabaseIfModelChanges<ESDbContext>
    {

        protected override void Seed(ESDbContext context)
        {

            List<User> users = new List<User>();
            users.Add(new User("JonSnow", "44f2ea859b70f5356621e259f6167bac", "44f2ea859b70f5356621e259f6167bac", "1@1.com"));//I know nothing
            users.Add(new User("SheldonCopper", "2f3e13074e3731eeff15f3da4918ebc8", "2f3e13074e3731eeff15f3da4918ebc8", "2@2.com"));//Bazzinga
            users.Add(new User("Sabina", "9b2b9ff87951a8ce6a157864ad935843", "9b2b9ff87951a8ce6a157864ad935843", "3@3.com"));//I hate kitsch
            users.Add(new User("Cosimo", "f7502cc1466096dacd7e6ea60afd5915", "f7502cc1466096dacd7e6ea60afd5915", "4@4.com"));//I live in tree
            users.Add(new User("Gatsby", "12bbbc83f7f249e8acb572184d3b68f3", "12bbbc83f7f249e8acb572184d3b68f3", "5@5.com"));//Greenlight
            foreach (User u in users)
                context.User.Add(u);

            List<Product> products = new List<Product>();

            //1,Spirit,2,Material,3,Relation,4,Personel,0,Others
            products.Add(new Product("Jean Valjean Diary", "Do you hear the people sing?", 30, "24601.jpg",5));
            products.Add(new Product("Colonel's Goldfish", "It's raining in Macondo", 50, "Goldfish.jpg",1));
            products.Add(new Product("T|D voucher", "Ask Shawn with this voucher, he will assure you a truth or a dare.", 200, "tod.jpg",0));
            products.Add(new Product("Sabina's hat", "My enemy is kitsch", 20, "hat.jpg",8));
            products.Add(new Product("Lord of Rings", "The one to rule them all.", 44, "ring.jpg",3));
            products.Add(new Product("Gatsby's greenlight", "So we beat on, boats against the current...", 10, "greenlight.bmp",6));
            products.Add(new Product("Ralph's conch", "Maybe there is a beast...", 30, "conch.jpg",1));
            products.Add(new Product("The Iron Throne", "Win or die in Westero.", 66, "Throne.jpg",3));
            products.Add(new Product("Cosimo's tree", "Disappear into the sky", 70, "tree.jpg",1));
            products.Add(new Product("Dragon Ball", "Collect total 7 to summon dragon.", 10, "dragonball.jpg",0));
            products.Add(new Product("OP Strawhat", "The hat Gold D Roger passed to Luffy.", 30, "strawhat.jpg",5));
            products.Add(new Product("Aladdin's Lamp", "Genie will grant you three wishes", 100, "aladdin.jpg",0));
            products.Add(new Product("Sheldon's Spot", "The center of Sheldon't universe", 55, "spot.jpg",7));
            products.Add(new Product("Andy's Rock Hammer", "The salvation lies within.", 65, "hammer.jpg", 5));
            products.Add(new Product("Little Prince's Rose", "You are my one unique rose .", 35, "rose.jpg", 6));
            products.Add(new Product("Sherlock's items", "It's my business to know what other people don't know.", 50, "sherlock.jpg", 7));
            products.Add(new Product("Cleopatra's eye shadow ", "I will not be triumphed over.", 10, "cleopatra.jpg", 8));
            products.Add(new Product("Happy Prince's lead heart", "You must kiss me on the lips, for I love you..", 80, "happyprince.jpg", 1));
            products.Add(new Product("Monte Cristo's treasure", "All human wisdom is contained in these two words - Wait and Hope.", 70, "cristo.jpg", 2));
            products.Add(new Product("Sandiago's fishboat", "A man can be destroyed but not defeated.", 50, "oldman.jpg", 4));
            products.Add(new Product("Carmen's scarlet skirt", "Carmen will always be free.", 20, "carmen.jpg", 8));

            products.Add(new Product("Marguerite's camelias ", "The end of this adventure becomes simply a matter of curiosity.", 15, "camelias.jpg", 8));
            products.Add(new Product("Peekay's remote control", "Which god shall I believe?", 35, "remote.jpg", 5));
            products.Add(new Product("Heart of Ocean", "My heart will go on...", 50, "heartofocean.jpg", 6));
            products.Add(new Product("Chihiro's train ticket", "Someday, we are getting on that train.", 5, "ticket.jpg", 5));
            products.Add(new Product("Bridget Jones's diary", "I like you, just as you are.", 10, "bjdiary.jpg", 6));
            products.Add(new Product("Goose that laid Golden egg", "Will you cook me?", 15, "goose.jpg", 2));
            products.Add(new Product("Jack's magic beans", "Exchange for your cow, deal or not?", 25, "bean.jpg", 2));
            products.Add(new Product("Cinderella's crystal shoe", "Always believe in a little magic", 7, "shoe.jpg", 8));
            products.Add(new Product("K3's music video", "Chit Kyout Yoon Shar", 50, "k3.jpg", 1));
            products.Add(new Product("Hulk's pants", "Hulk is angery!", 10, "hulk.jpg", 3));
            products.Add(new Product("Bertrand Russell's teapot", "Do not fear to be eccentric in opinion.", 66, "teapot.jpg", 7));
            products.Add(new Product("Issac Newton's apple", "By standing on the shoulders of giants", 5, "newton.jpg", 7));
            products.Add(new Product("Lasso of Truth", "Now I know that only love can truly save the world.", 44, "lasso.jpg", 3));
            products.Add(new Product("Leon's potted plant", "I hope you are not lying, Leon.", 20, "leon.jpg", 6));
            products.Add(new Product("Amelia's travelling Gnome", "You don't have bones of glass.", 5, "gnome.jpg", 4));

            foreach (Product p in products)
                context.Product.Add(p);
                context.SaveChanges();
            
            List<ActCode> LA = new List<ActCode>();
            LA.Add(new ActCode(1, 1, Guid.NewGuid(), DateTime.Today.Date.AddYears(-1)));
            LA.Add(new ActCode(1, 2, Guid.NewGuid(), DateTime.Today.Date.AddYears(-1)));
            LA.Add(new ActCode(1, 3, Guid.NewGuid(), DateTime.Today.Date.AddDays(-50)));
            LA.Add(new ActCode(1, 4, Guid.NewGuid(), DateTime.Today.Date.AddDays(-50)));
            LA.Add(new ActCode(1, 5, Guid.NewGuid(), DateTime.Today.Date));
            foreach (ActCode a in LA)
                context.ActCode.Add(a);

            context.SaveChanges();


            base.Seed(context);
        }

    }
}