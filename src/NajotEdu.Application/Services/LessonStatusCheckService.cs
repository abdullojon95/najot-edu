using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NajotEdu.Application.Abstractions;

namespace NajotEdu.Application.Services
{
    public class LessonStatusCheckService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        public LessonStatusCheckService(IServiceProvider provider)
        {
            _provider = provider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var period = new PeriodicTimer(TimeSpan.FromSeconds(10));

            while (await period.WaitForNextTickAsync(stoppingToken))
            {
               var scope = _provider.CreateScope();
               var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

               var lessons = await context.Lessons
                    .Include(x => x.Attendances)
                    .Where(x =>
                    x.EndDateTime.Date == DateTime.Now.Date &&
                    x.EndDateTime < DateTime.Now)
                    .ToListAsync(stoppingToken);
                
                foreach(var lesson in lessons)
                {
                    lesson.IsDone = lesson.Attendances.Any();
                    context.Lessons.Update(lesson);
                }
                await context.SaveChangesAsync(stoppingToken);
            }
        }
    }
}
