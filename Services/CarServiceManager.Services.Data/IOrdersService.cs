namespace CarServiceManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        //Task CreateAsync(CourseInputModel input, string userId);

        Task<IEnumerable<T>> GetAll<T>();

        //Task<IEnumerable<T>> GetAll<T>(int page, int itemsPerPage = 8);

        //int GetCount();

        //Task<T> GetByIdAsync<T>(int id);

        //Task<T> GetByIdAsync<T>(string id);

        //Task DeleteAsync(int id);

        //Task UpdateAsync(int id, EditCourseInputModel input);

        //Task AddStudentAsync(CourseStudentInputModel input);

        //Task RemoveStudentAsync(CourseStudentInputModel input);

        //Task<IEnumerable<CourseAddStudentViewModel>> GetAvailableStudents(int id);
    }
}
