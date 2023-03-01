using NajotEdu.Application.Models;

namespace NajotEdu.Application.Abstractions
{
    public interface ITeacherService
    {
        Task<TeacherViewModel> GetByIdAsync(int id);
        Task<List<TeacherViewModel>> GetAllAsync();
        Task CreateAsync(CreateTeacherModel model);
        Task UpdateAsync(UpdateTeacherModel model);
        Task DeleteAsync(int id);
    }
}
