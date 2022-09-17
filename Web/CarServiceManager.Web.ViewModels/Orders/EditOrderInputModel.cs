namespace CarServiceManager.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class EditOrderInputModel : OrderInputModel,
        IMapFrom<Order>
    {
        public int Id { get; set; }

        [Display(Name = "Дата и час")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
