namespace CarServiceManager.Data.Models
{
    using System.Collections.Generic;

    using CarServiceManager.Data.Common.Models;

    public class Color : BaseDeletableModel<int>
    {
        public Color()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}