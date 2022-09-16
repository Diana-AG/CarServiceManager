namespace CarServiceManager.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Common;
    using CarServiceManager.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class ManagerSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.ManagerAccountsSeeding.Email,
                GlobalConstants.ManagerAccountsSeeding.FullName,
                GlobalConstants.ManagerAccountsSeeding.Password,
                GlobalConstants.ManagerRoleName);
        }

        private static async Task CreateUser(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            string email,
            string fullName,
            string password,
            string roleName)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName,
            };

            var role = await roleManager.FindByNameAsync(roleName);

            if (!userManager.Users.Any(x => x.UserName == user.UserName))
            {
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}