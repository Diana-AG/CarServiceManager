namespace CarServiceManager.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Data;
    using CarServiceManager.Web.ViewModels.Cars;
    using CarServiceManager.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly ICarsService carsService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(
            IOrdersService ordersService,
            ICarsService carsService,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.carsService = carsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new OrderListViewModel
            {
                Orders = await this.ordersService.GetAll<OrderInListViewModel>(),
                CurrentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            };

            return this.View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            var viewModel = new OrderInputModel
            {
                Car = await this.carsService.GetByIdAsync<CarInListViewModel>(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.ordersService.CreateAsync(input, user.Id);

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = await this.ordersService.GetByIdAsync<EditOrderInputModel>(id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditOrderInputModel input)
        {
            if (id != input.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.ordersService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await this.ordersService.GetByIdAsync<OrderInListViewModel>(id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.View(order);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.ordersService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
