namespace CarServiceManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Data.Common.Repositories;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;
    using CarServiceManager.Web.ViewModels.Cars;
    using Microsoft.EntityFrameworkCore;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IDeletableEntityRepository<Brand> brandsRepository;
        private readonly IDeletableEntityRepository<Color> colorsRepository;

        public CarsService(IDeletableEntityRepository<Car> carsRepository, IDeletableEntityRepository<Brand> brandsRepository, IDeletableEntityRepository<Color> colorsRepository)
        {
            this.carsRepository = carsRepository;
            this.brandsRepository = brandsRepository;
            this.colorsRepository = colorsRepository;
        }

        public async Task CreateAsync(CarInputModel input)
        {
            var car = this.carsRepository.All().FirstOrDefault(x => x.RegistrationNumber == input.RegistrationNumber);
            if (car != null)
            {
                throw new Exception($"Автомобил с регистрационне номер \"{input.RegistrationNumber}\" вече съществува");
            }

            car = new Car
            {
                RegistrationNumber = input.RegistrationNumber,
                BrandId = input.BrandId,
                ColorId = input.ColorId,
            };

            await this.carsRepository.AddAsync(car);
            await this.carsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var cars = await this.carsRepository.AllAsNoTracking()
                .OrderBy(x => x.Brand.Name)
                .To<T>().ToListAsync();

            return cars;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllBrandsAsKeyValuePair()
        {
            return this.brandsRepository.All()
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllColorsAsKeyValuePair()
        {
            return this.colorsRepository.All()
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var car = await this.carsRepository.AllAsNoTracking()
                           .Where(x => x.Id == id)
                           .To<T>().FirstOrDefaultAsync();

            return car;
        }
    }
}
