using Microsoft.EntityFrameworkCore;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Models;
using NajotEdu.Domain.Entities;

namespace NajotEdu.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public AttendanceService(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task CheckAsync(DoAttendanceCheckModel model)
        {
            var lesson = await _context.Lessons.Include(x => x.Group).FirstOrDefaultAsync(x => x.Id == model.LessonId);

            if (lesson == null)
            {
                throw new Exception("Not found");
            }

            var groupStudents = await _context.Lessons
                .Where(x => x.Id == model.LessonId)
                .Include(x => x.Group)
                .ThenInclude(x => x.GroupStudents)
                .SelectMany(x => x.Group.GroupStudents)
                .Select(x => x.StudentId)
                .ToListAsync();

            var attendanceList = new List<Attendance>();

            foreach (var studentId in groupStudents)
            {
                var check = model.Checks.FirstOrDefault(x => x.StudentId == studentId);

                var attendance = new Attendance()
                {
                    StudentId = studentId,
                    LessonId = model.LessonId,
                    HasParticipated = false
                };

                if (check != null)
                {
                    attendance.HasParticipated = check.HasParticipated;
                }
                attendanceList.Add(attendance);
            }
            _context.Attendances.AddRange(attendanceList);

            await _context.SaveChangesAsync();
        }
    }
}
