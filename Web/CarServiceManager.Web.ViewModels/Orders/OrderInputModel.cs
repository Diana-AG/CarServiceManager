namespace CarServiceManager.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarServiceManager.Web.ViewModels.Cars;

    public class OrderInputModel
    {
        [Display(Name = "Дата и час")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int CarId { get; set; }

        public CarInListViewModel Car { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10000)]
        [Display(Name = "Описание на проблема")]

        public string Description { get; set; }
    }
}
