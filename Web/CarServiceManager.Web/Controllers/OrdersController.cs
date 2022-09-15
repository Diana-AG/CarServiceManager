namespace CarServiceManager.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
