namespace CarServiceManager.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class CarInListViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int CarId { get; set; }

        [Display(Name = "Марка")]
        public string CarBrandName { get; set; }

        [Display(Name = "Цвят")]
        public string CarColorName { get; set; }

        [Display(Name = "Регистрационне номер")]
        public string RegistrationNumber { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarInListViewModel>()
                  .ForMember(x => x.CarId, options =>
                      options.MapFrom(x => x.Id))
                  .ForMember(x => x.CarBrandName, options =>
                      options.MapFrom(x => x.Brand.Name))
                  .ForMember(x => x.CarColorName, options =>
                      options.MapFrom(x => x.Color.Name));
        }
    }
}
