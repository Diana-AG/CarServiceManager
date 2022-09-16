namespace CarServiceManager.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrderListViewModel
    {
        public IEnumerable<OrderInListViewModel> Orders { get; set; }

        public string CurrentUserId { get; set; }
    }
}
