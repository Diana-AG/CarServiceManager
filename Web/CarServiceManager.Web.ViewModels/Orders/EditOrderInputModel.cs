namespace CarServiceManager.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class EditOrderInputModel : OrderInputModel, IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Дата и час")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, EditOrderInputModel>()
                .ForMember(x => x.Date, options =>
                    options.MapFrom(x => x.Date.AddTicks(-(x.Date.Ticks % TimeSpan.TicksPerMinute))));
        }
    }
}
