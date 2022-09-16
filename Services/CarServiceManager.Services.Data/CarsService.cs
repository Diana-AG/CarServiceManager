namespace CarServiceManager.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarServiceManager.Data.Common.Repositories;
    using CarServiceManager.Data.Models;

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
    }
}
