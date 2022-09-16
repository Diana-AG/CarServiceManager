namespace CarServiceManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Data.Common.Repositories;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            var orders = await this.ordersRepository.AllAsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.AddedByUser)
                .OrderByDescending(x => x.Id)
                .To<T>().ToListAsync();

            return orders;
        }
    }
}
