namespace CarServiceManager.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class CarInListViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Display(Name = "Марка")]
        public string CarBrandName { get; set; }

        [Display(Name = "Цвят")]
        public string CarColorName { get; set; }

        [Display(Name = "Регистрационне номер")]
        public string RegistrationNumber { get; set; }
    }
}
