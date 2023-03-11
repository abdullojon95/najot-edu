using NajotEdu.Application.Models;

namespace NajotEdu.Application.Abstractions
{
    public interface IAttendanceService
    {
        Task CheckAsync(DoAttendanceCheckModel model);
    }
}
