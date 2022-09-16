namespace CarServiceManager.Web.ViewModels.Orders
{
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class EditOrderInputModel : OrderInputModel,
        IMapFrom<Order>
    {
        public int Id { get; set; }
    }
}
