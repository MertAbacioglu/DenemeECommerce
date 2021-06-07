using Bogus.DataSets;
using Project.DAL.Context;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<MyContext>
    {
        //db tam olusurken veri ekleyebilmek için Seed metodunu override edeceğiz.
        protected override void Seed(MyContext context)
        {
            #region Admin
            AppUser au = new AppUser();
            au.UserName = "mertabc";
            au.Password = "123";
            au.Email = "mert.abacioglu@hotmail.com";
            au.AppUserRole = Entities.Enums.AppUserRole.Admin;
            context.AppUsers.Add(au);
            context.SaveChanges(); //au nesnesinin ID si buradan sonra olusuyor.

            UserProfile up = new UserProfile();
            up.ID = au.ID;
            up.FirstName = "Mert";
            up.LastName = "Abacioglu";
            up.Address = "Kadıköy";

            #endregion

            for (int i = 0; i < 10; i++)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = new Internet("tr").UserName();
                appUser.Password = new Internet("tr").Password();
                appUser.Email = new Internet("tr").Email();

                context.AppUsers.Add(appUser);
            }
            context.SaveChanges();

            for (int i = 2; i < 12; i++)
            {
                UserProfile userProfileMember = new UserProfile();
                userProfileMember.ID = i;
                userProfileMember.FirstName = new Name("tr").FirstName();
                userProfileMember.LastName = new Name("tr").LastName();
                userProfileMember.Address = new Address("tr").Locale;
                context.Profiles.Add(userProfileMember);
            }
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                Category c = new Category();
                c.CategoryName = new Commerce("tr").Categories(1)[0];
                c.Description = new Lorem("tr").Sentence(10);
                for (int j = 0; j < 30; j++)
                {
                    Product p = new Product();
                    p.ProductName = new Commerce("tr").ProductName();
                    p.UnitPrice = Convert.ToDecimal(new Commerce("tr").Price());
                    p.UnitsInStock = 100;
                    //p.ImagePath = new Images().Nightlife();
                    p.ImagePath = new Images().PicsumUrl(width:300,height:200,blur:false,imageId:null);

                    c.Products.Add(p);
                }
                context.Categories.Add(c);
               
                context.SaveChanges();
            }
        }
    }
}
