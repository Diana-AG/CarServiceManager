namespace CarServiceManager.Web.ViewModels.Orders
{
    using CarServiceManager.Web.ViewModels.Cars;
    using System.ComponentModel.DataAnnotations;

    public class OrderInputModel
    {
        public int CarId { get; set; }

        public CarInListViewModel Car { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10000)]
        [Display(Name = "Описание на проблема")]

        public string Description { get; set; }
    }
}
