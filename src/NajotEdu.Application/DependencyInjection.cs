using Microsoft.Extensions.DependencyInjection;
using NajotEdu.Application.Abstractions;
using NajotEdu.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotEdu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService,TeacherService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
