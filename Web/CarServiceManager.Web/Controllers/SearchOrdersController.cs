namespace CarServiceManager.Web.Controllers
{
    using System.Security.Claims;

    using CarServiceManager.Services.Data;
    using CarServiceManager.Web.ViewModels.Orders;
    using CarServiceManager.Web.ViewModels.SearchOrders;
    using Microsoft.AspNetCore.Mvc;

    public class SearchOrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        public SearchOrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Search(SearchOrdersInputModel input)
        {
            var viewModel = new OrderListViewModel
            {
                Orders = this.ordersService.GetBySearch<OrderInListViewModel>(input.KeyWord),
                CurrentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            };

            return this.View(viewModel);
        }
    }
}
