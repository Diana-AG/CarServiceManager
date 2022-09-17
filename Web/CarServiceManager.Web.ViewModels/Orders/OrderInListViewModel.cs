namespace CarServiceManager.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class OrderInListViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        [Display(Name = "Номер на заявката")]
        public string Id { get; set; }

        [Display(Name = "Дата и час")]
        public string Date { get; set; }

        [Display(Name = "Автомобил")]
        public string CarBrandName { get; set; }

        [Display(Name = "Описание на проблема")]
        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        [Display(Name = "Добавена от")]
        public string AddedByUserFullName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, OrderInListViewModel>()
                .ForMember(x => x.Id, options =>
                    options.MapFrom(x => x.Id.ToString("0000000000")))
                .ForMember(x => x.Date, options =>
                    options.MapFrom(x => x.Date.ToString("dd-MM-yyyy HH:mm")));
        }
    }
}
