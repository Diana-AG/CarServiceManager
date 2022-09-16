namespace CarServiceManager.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarServiceManager.Data.Models;

    public class OrderInputModel
    {
        [Display(Name = "Дата и час")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Автомобил")]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10000)]
        [Display(Name = "Описание на проблема")]

        public string Description { get; set; }
    }
}
