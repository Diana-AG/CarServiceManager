namespace CarServiceManager.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarServiceManager.Common;

    internal class ColorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Colors.Any())
            {
                return;
            }

            await dbContext.Colors.AddAsync(new Models.Color { Name = GlobalConstants.ColorsSeeding.White });
            await dbContext.Colors.AddAsync(new Models.Color { Name = GlobalConstants.ColorsSeeding.Black });
            await dbContext.Colors.AddAsync(new Models.Color { Name = GlobalConstants.ColorsSeeding.GrayMetalic });
            await dbContext.Colors.AddAsync(new Models.Color { Name = GlobalConstants.ColorsSeeding.Red });
            await dbContext.Colors.AddAsync(new Models.Color { Name = GlobalConstants.ColorsSeeding.Blue });
            await dbContext.Colors.AddAsync(new Models.Color { Name = GlobalConstants.ColorsSeeding.Green });

            await dbContext.SaveChangesAsync();
        }
    }
}