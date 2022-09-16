namespace CarServiceManager.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class CarListViewModel
    {
        public IEnumerable<CarInListViewModel> Cars { get; set; }
    }
}
