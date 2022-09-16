namespace CarServiceManager.Data.Models
{
    using System;

    using CarServiceManager.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public DateTime Date { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
