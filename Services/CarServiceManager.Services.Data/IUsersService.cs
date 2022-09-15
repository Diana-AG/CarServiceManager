namespace CarServiceManager.Services.Data
{
    using System.Collections.Generic;

    using CarServiceManager.Web.ViewModels.Users;

    public interface IUsersService
    {
        IEnumerable<UsersInListViewModel> GetAll();
    }
}
