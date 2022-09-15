namespace CarServiceManager.Web.Controllers
{
    using CarServiceManager.Web.ViewModels.SearchOrders;
    using Microsoft.AspNetCore.Mvc;

    public class SearchOrdersController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Search(SearchInputModel input)
        {
            return this.View();
        }
    }
}
