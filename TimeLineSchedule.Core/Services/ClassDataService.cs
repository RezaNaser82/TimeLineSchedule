using Hangfire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services
{
    public class ClassDataService : IClassDataService
    {
        private readonly TimeLineContext _context;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public ClassDataService(TimeLineContext context , IBackgroundJobClient backgroundJobClient)
        {
            _context = context;
            _backgroundJobClient = backgroundJobClient;
        }
        public IEnumerable<ClassData> GetAllClassData()
        {
            return _context.ClassDatas.OrderBy(c=>c.DayOfClass).ToList();
        }

        public ClassData GetClassDataById(int id)
        {
            return _context.ClassDatas.FirstOrDefault(cd => cd.Id == id);
        }

       
        public void ScheduleOrImmediateClassOperation(ClassData classData)
        {
            if (classData.ScheduledDate == null || classData.ScheduledDate <= DateTime.Now)
            {
                // Immediate creation/update
                CreateOrUpdateClass(classData);
            }
        else
            {
                // Queue job in Hangfire
                _backgroundJobClient.Schedule(
                    () => CreateOrUpdateClass(classData),
                    classData.ScheduledDate.Value
                );
            }
        }

        // This method can be private if only called by this service
        public void CreateOrUpdateClass(ClassData classData)
        {
            if (classData.Id == 0)
            {
                _context.ClassDatas.Add(classData);
            }
            else
            {
                _context.ClassDatas.Update(classData);
            }
            _context.SaveChanges();
        }
        public void UpdateClassData(ClassData classData)
        {
            _context.Update(classData);
            _context.SaveChanges();
        }
        public void CreateClassData(ClassData classData)
        {
            _context.ClassDatas.FirstOrDefault(cd => cd.IsNew == true);
            _context.ClassDatas.Add(classData);
            _context.SaveChanges();
        }
        public void CleanupClasses()
        {
            var newClasses = _context.ClassDatas.Where(c => c.IsNew == true).ToList();
            _context.ClassDatas.RemoveRange(newClasses);

            var updatedClasses = _context.ClassDatas.Where(c => c.IsUpdated == true && c.ClassStatus == false).ToList();
            foreach (var updatedClass in updatedClasses)
            {
                updatedClass.ClassStatus = true;
            }

            _context.SaveChanges();
        }
    }
}
