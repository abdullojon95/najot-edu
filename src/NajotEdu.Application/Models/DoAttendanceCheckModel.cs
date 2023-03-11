namespace NajotEdu.Application.Models
{
    public class DoAttendanceCheckModel
    {
        public int LessonId { get; set; }
        public List<AttendanceCheckModel> Checks { get; set; }
    }
}
