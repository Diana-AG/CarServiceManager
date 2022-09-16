namespace CarServiceManager.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CarServiceManager.Services.Data;
    using CarServiceManager.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
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

        public IActionResult Create()
        {
            var viewModel = new OrderInputModel
            {
                Date = DateTime.Now,
            };

            return this.View(viewModel);
        }
    }
}
