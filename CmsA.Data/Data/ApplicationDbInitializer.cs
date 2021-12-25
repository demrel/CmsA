using Identity.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsA.Data.Data;

    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new AppUser
                {
                    UserName = "admin",
                };
            //visa MUSIC 5 yelp egg 6 COFFEE 4 9 skype hulu 8 nut hulu NUT music golf 9 nut GOLF
            IdentityResult result = userManager.CreateAsync(user, "vM5ye6C49sh8nhNmg9nG").Result;

                if (result.Succeeded)
                {

                    var roleAdmin = new AppRole
                    {
                        Name = "Admin"
                    };
                    roleManager.CreateAsync(roleAdmin).Wait();

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }

