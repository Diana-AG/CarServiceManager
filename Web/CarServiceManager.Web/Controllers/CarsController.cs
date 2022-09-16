namespace CarServiceManager.Web.Controllers
{
    using CarServiceManager.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CarsController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            //var model = new CarListViewModel
            //{
                
            //};

            return this.View();
        }

        public IActionResult Create()
        {
           return this.View();
        }
    }
}
