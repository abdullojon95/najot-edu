using NajotEdu.Application.Models;

namespace NajotEdu.Application.Abstractions
{
    public interface IStudentService : ICrudService<int, StudentViewModel, CreateStudentModel, UpdateStudentModel>
    {
    }
}
