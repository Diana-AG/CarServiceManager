namespace CarServiceManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Data.Common.Repositories;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;
    using CarServiceManager.Web.ViewModels.Orders;
    using Microsoft.EntityFrameworkCore;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task CreateAsync(OrderInputModel input, string userId)
        {
            var order = new Order
            {
                CarId = input.CarId,
                Date = DateTime.Now,
                Description = input.Description,
                AddedByUserId = userId,
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await this.ordersRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.ordersRepository.Delete(order);
            await this.ordersRepository.SaveChangesAsync();
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

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var order = await this.ordersRepository.AllAsNoTracking()
                           .Where(x => x.Id == id)
                           .To<T>().FirstOrDefaultAsync();

            return order;
        }

        public IEnumerable<T> GetBySearch<T>(string searchInput)
        {
            searchInput = searchInput.Trim();
            var orders = this.ordersRepository.All()
                .Where(x => x.Id.ToString().Contains(searchInput)
                || x.Date.ToString().Contains(searchInput)
                || x.Car.Brand.Name.Contains(searchInput)
                || x.Car.Color.Name.Contains(searchInput)
                || x.Car.RegistrationNumber.Contains(searchInput))
                .To<T>().ToList();

            return orders;
        }

        public async Task UpdateAsync(int id, EditOrderInputModel input)
        {
            var order = this.ordersRepository.All().FirstOrDefault(x => x.Id == id);
            order.CarId = input.CarId;
            order.Date = input.Date;
            order.Description = input.Description;

            await this.ordersRepository.SaveChangesAsync();
        }
    }
}
