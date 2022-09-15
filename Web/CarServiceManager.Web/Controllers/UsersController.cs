namespace CarServiceManager.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarServiceManager.Common;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Data;
    using CarServiceManager.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class UsersController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IUserEmailStore<ApplicationUser> emailStore;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IUsersService userService;

        public UsersController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            //IUserEmailStore<ApplicationUser> emailStore,
            RoleManager<ApplicationRole> roleManager,
            IUsersService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
            //this.emailStore = emailStore;
            this.roleManager = roleManager;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var viewModel = new UsersListViewModel
            {
                Users = this.userService.GetAll(),
            };

            return this.View(viewModel);
        }

        public IActionResult Register()
            => this.View();

        [HttpPost]
        public IActionResult Register(RegisterUserInputModel input)
        {
            IEnumerable<ApplicationRole> roles = this.roleManager.Roles.ToList();
            this.ViewData["RoleId"] = new SelectList(roles.ToList(), "Id", "Name");

            return this.Redirect("/Users/Login");
        }

        public IActionResult Login()
        {
            return this.View();

            // return this.Login(new LoginUserInputModel { Username = "manager@carservice.com", Password = "123123" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserInputModel input)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(input.Email, input.Password, input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", nameof(OrdersController));
                }

                return this.View();
            }

            this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            return this.View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        public IActionResult Edit()
            => this.View();
    }
}
