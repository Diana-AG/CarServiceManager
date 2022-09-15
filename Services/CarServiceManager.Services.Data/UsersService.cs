namespace CarServiceManager.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Data.Common.Repositories;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;
    using CarServiceManager.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.userManager = userManager;
            this.usersRepository = usersRepository;
        }

        public IEnumerable<UsersInListViewModel> GetAll()
        {
            var users = this.usersRepository.All()
                .OrderBy(x => x.FullName)
                .Select(x => new UsersInListViewModel
                {
                    Email = x.Email,
                    FullName = x.FullName,
                    Role = string.Join(",", this.userManager.GetRolesAsync(x).Result.ToArray()),
                })
                .ToList();

            return users;
        }
    }
}
