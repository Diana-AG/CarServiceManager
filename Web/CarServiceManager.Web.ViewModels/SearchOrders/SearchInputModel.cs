namespace CarServiceManager.Web.ViewModels.SearchOrders
{
    using System.ComponentModel.DataAnnotations;

    public class SearchOrdersInputModel
    {
        [Required]
        [Display(Name = "Търсене в заявките")]
        public string KeyWord { get; set; }
    }
}
