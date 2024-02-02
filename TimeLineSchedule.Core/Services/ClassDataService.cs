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
            return _context.ClassDatas.OrderBy(c=>c.DayOfClass).ThenBy(c=>c.ClassStart).ToList();
        }

        public ClassData GetClassDataById(int id)
        {
            return _context.ClassDatas.FirstOrDefault(cd => cd.Id == id);
        }
        public void CreateOrUpdateClassData(ClassData classData)
        {

            if (classData.ScheduledDate.HasValue && classData.ScheduledDate.Value > DateTime.Now)
            {
                BackgroundJob.Schedule(() => CreateOrUpdateClassRealMethod(classData), classData.ScheduledDate.Value);
            }
            else
            {
                CreateOrUpdateClassDataInternal(classData);
            }
        }

        private void CreateOrUpdateClassDataInternal(ClassData classData)
        {
            if (classData.Id == 0)
            {
                _context.ClassDatas.Add(classData);
            }
            else
            {
                var existingClassData = _context.ClassDatas.Find(classData.Id);
                if (existingClassData != null)
                {
                    _context.Entry(existingClassData).CurrentValues.SetValues(classData);
                }
            }
            _context.SaveChanges();
        }

        [AutomaticRetry(Attempts = 0)]
        public void CreateOrUpdateClassRealMethod(ClassData classData)
        {
            CreateOrUpdateClassDataInternal(classData);
        }
       
        public void DeleteNewClasses()
        {
            var newClasses = _context.ClassDatas.Where(c => c.IsNew.HasValue && c.IsNew.Value).ToList();
            foreach (var classData in newClasses)
            {
                _context.ClassDatas.Remove(classData);
            }
            _context.SaveChanges();
        }
        
        public void ActivateClasses()
        {
            var inactiveClasses = _context.ClassDatas.Where(c => c.ClassStatus.HasValue && !c.ClassStatus.Value).ToList();
            foreach (var classData in inactiveClasses)
            {
                classData.ClassStatus = true;
            }
            _context.SaveChanges();
        }

        public void RemoveClasses(ClassData classData)
        {
            var existingClassData = _context.ClassDatas.Find(classData.Id);
            if (existingClassData != null)
            {
                _context.Remove(existingClassData);
                _context.SaveChanges();

            }
        }
    }
}
