namespace CarServiceManager.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using CarServiceManager.Data.Models;
    using CarServiceManager.Services.Mapping;

    public class UsersInListViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Име")]
        public string FullName { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Роля")]
        public string Role { get; set; }
    }
}
