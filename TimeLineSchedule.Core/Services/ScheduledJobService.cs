using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Context;

namespace TimeLineSchedule.Core.Services
{
    public class ScheduledJobService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;
        

        public ScheduledJobService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
          
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1440)); 

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var now = DateTime.UtcNow; 

            
            if (now.DayOfWeek == DayOfWeek.Friday && now.Hour == 0 && now.Minute < 1)
            {
                UpdateClassStatuses().Wait();
            }
        }

        private async Task UpdateClassStatuses()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TimeLineContext>();

                var classesToUpdate = await dbContext.ClassDatas
                    .Where(c => (bool)!c.ClassStatus)
                    .ToListAsync();

                foreach (var classData in classesToUpdate)
                {
                    classData.ClassStatus = true;
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

   
}
