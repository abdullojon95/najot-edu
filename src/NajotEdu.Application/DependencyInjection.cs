using Microsoft.Extensions.DependencyInjection;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Services;

namespace NajotEdu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IProfileService, ProfileService>();

            return services;
        }
    }
}
