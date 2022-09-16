namespace CarServiceManager.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarServiceManager.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task CreateAsync(CarInputModel input);

        IEnumerable<KeyValuePair<string, string>> GetAllBrandsAsKeyValuePair();

        IEnumerable<KeyValuePair<string, string>> GetAllColorsAsKeyValuePair();
    }
}
