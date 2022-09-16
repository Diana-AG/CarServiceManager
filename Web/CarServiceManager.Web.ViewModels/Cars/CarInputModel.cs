namespace CarServiceManager.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarInputModel
    {
        [Display(Name = "Марка")]
        public int BrandId { get; set; }

        [Display(Name = "Цвят")]
        public int ColorId { get; set; }

        [Required]
        [Display(Name = "Регистрационен номер")]
        public string RegistrationNumber { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BrandsItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ColorsItems { get; set; }
    }
}
