using NajotEdu.Application.Models;

namespace NajotEdu.Application.Abstractions
{
    public interface ITeacherService : ICrudService<int, TeacherViewModel, CreateTeacherModel, UpdateTeacherModel>
    {
    }
}
