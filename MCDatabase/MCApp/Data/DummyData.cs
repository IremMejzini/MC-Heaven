using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MCApp.Data
{
    public class DummyData
    {
        public static async Task CreateUserRoles(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            //initializing custom roles   
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";
            String managerId1 = "";
            String managerId2 = "";

            string role1 = "Admin";
            string desc1 = "This is admin role";

            string role2 = "Member";
            string desc2 = "This is member role";

            string role3 = "User";
            string desc3 = "This is user role";

            string password = "Pa55w.rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }


            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync("beata@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "beata@gmail.com",
                    Email = "beata@gmail.com",
                    UserLogin = "Beata1",
                    FirstName = "Beata",
                    LastName = "Zalewa",
                    Age = 18,
                    PhoneNumber = "600600600"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await roleManager.FindByNameAsync("simon@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "simon@gmail.com",
                    Email = "simon@gmail.com",
                    UserLogin = "NewUser2",
                    FirstName = "Simon",
                    LastName = "Cat",
                    Age = 2,
                    PhoneNumber = "700700700"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId2 = user.Id;
            }

            if (await roleManager.FindByNameAsync("romek@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "romek@gmail.com",
                    Email = "romek@gmail.com",
                    UserLogin = "Romek45",
                    FirstName = "Roman",
                    LastName = "Zalewa",
                    Age = 45,
                    PhoneNumber = "500500500"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
                managerId1 = user.Id;
            }

            if (await roleManager.FindByNameAsync("darek@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "darek@gmail.com",
                    Email = "darek@gmail.com",
                    UserLogin = "Darek32",
                    FirstName = "Dariusz",
                    LastName = "Zalewa",
                    Age = 45,
                    PhoneNumber = "500500500"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
                managerId2 = user.Id;
            }

            if (await roleManager.FindByNameAsync("daria@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "daria@gmail.com",
                    Email = "daria@gmail.com",
                    UserLogin = "Daria14",
                    FirstName = "Daria",
                    LastName = "Zalewa",
                    Age = 40,
                    PhoneNumber = "400400400"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
            }

            if (await roleManager.FindByNameAsync("charlie@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "charlie@gmail.com",
                    Email = "charlie@gmail.com",
                    UserLogin = "Charlie4",
                    FirstName = "Charlie",
                    LastName = "Dog",
                    Age = 40,
                    PhoneNumber = "300300300"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
            }
        }
    }
 
}

