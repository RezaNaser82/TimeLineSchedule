using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services
{
    public class ClassesService : IClassesService
    {
        private readonly TimeLineContext _context;

        public ClassesService(TimeLineContext context)
        {
            _context = context;
        }

        public async Task<List<ClassData>> GetClassesForTodayAsync()
        {
            DateTime now = DateTime.Now;
            DayOfWeek today = now.DayOfWeek;
            TimeOnly oneHourBeforeNow = new TimeOnly(now.AddHours(-1).Hour, 0, 0);
            TimeOnly oneHourAfterNow = new TimeOnly(now.AddHours(1).Hour, 0, 0);

            return await _context.ClassDatas
                .Where(c => c.DayOfClass == today &&
                            c.ClassStart >= oneHourBeforeNow &&
                            c.ClassStart <= oneHourAfterNow)
                .ToListAsync();
        }
    }
}