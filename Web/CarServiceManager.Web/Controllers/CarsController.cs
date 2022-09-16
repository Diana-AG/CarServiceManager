namespace CarServiceManager.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CarServiceManager.Services.Data;
    using CarServiceManager.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : BaseController
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CarListViewModel
            {
                Cars = await this.carsService.GetAllAsync<CarInListViewModel>(),
            };

            return this.View(model);
        }

        public IActionResult Create()
        {
            var input = new CarInputModel
            {
                BrandsItems = this.carsService.GetAllBrandsAsKeyValuePair(),
                ColorsItems = this.carsService.GetAllColorsAsKeyValuePair(),
            };

            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.carsService.CreateAsync(input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
