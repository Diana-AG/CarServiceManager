namespace CarServiceManager.Data.Models
{
    using System.Collections.Generic;

    using CarServiceManager.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Orders = new HashSet<Order>();
        }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public string RegistrationNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
