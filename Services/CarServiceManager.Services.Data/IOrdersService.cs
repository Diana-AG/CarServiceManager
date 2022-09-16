namespace CarServiceManager.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarServiceManager.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task CreateAsync(OrderInputModel input, string userId);

        Task<IEnumerable<T>> GetAll<T>();

        Task<T> GetByIdAsync<T>(int id);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, EditOrderInputModel input);
    }
}
