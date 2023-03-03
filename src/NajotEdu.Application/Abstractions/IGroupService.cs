using NajotEdu.Application.Models;

namespace NajotEdu.Application.Abstractions
{
    public interface IGroupService : ICrudService<int, GroupViewModel, CreateGroupModel, UpdateGroupModel>
    {
        Task AddStudentAsync(AddStudentGroupModel model, int groupId);
        Task RemoveStudentAsync(int studentId, int groupId);
    }
}
