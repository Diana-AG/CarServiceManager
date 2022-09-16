namespace CarServiceManager.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Common;

    internal class BrandsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Brands.Any())
            {
                return;
            }

            await dbContext.Brands.AddAsync(new Models.Brand { Name = GlobalConstants.BrandsSeeding.Audi });
            await dbContext.Brands.AddAsync(new Models.Brand { Name = GlobalConstants.BrandsSeeding.BMV });
            await dbContext.Brands.AddAsync(new Models.Brand { Name = GlobalConstants.BrandsSeeding.Mercedes });
            await dbContext.Brands.AddAsync(new Models.Brand { Name = GlobalConstants.BrandsSeeding.VW });

            await dbContext.SaveChangesAsync();
        }
    }
}
