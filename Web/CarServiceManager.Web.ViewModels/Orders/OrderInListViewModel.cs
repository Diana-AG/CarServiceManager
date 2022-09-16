namespace CarServiceManager.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class OrderInListViewModel : IMapFrom<Order>
    {
        [Display(Name = "Номер на заявката")]
        public int Id { get; set; }

        [Display(Name = "Дата и час")]
        public DateTime Date { get; set; }

        [Display(Name = "Автомобил")]
        public string CarName { get; set; }

        [Display(Name = "Описание на проблема")]
        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        [Display(Name = "Добавена от")]
        public string AddedByUserFullName { get; set; }
    }
}