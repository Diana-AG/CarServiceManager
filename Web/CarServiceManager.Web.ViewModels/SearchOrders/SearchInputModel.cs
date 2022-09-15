namespace CarServiceManager.Web.ViewModels.SearchOrders
{
    using System.ComponentModel.DataAnnotations;

    public class SearchInputModel
    {
        [Required]
        [Display(Name = "Търсене в заявките")]
        public string KeyWord { get; set; }
    }
}
