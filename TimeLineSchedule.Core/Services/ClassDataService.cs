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
    public class ClassDataService : IClassDataService
    {
        private readonly TimeLineContext _context;

        public ClassDataService(TimeLineContext context)
        {
            _context = context;
        }
        public IEnumerable<ClassData> GetAllClassData()
        {
            return _context.ClassDatas.OrderBy(c=>c.DayOfClass).ToList();
        }

        public ClassData GetClassDataById(int id)
        {
            return _context.ClassDatas.FirstOrDefault(cd => cd.Id == id);
        }

        public void UpdateClassData(ClassData classData)
        {
            _context.Update(classData);
            _context.SaveChanges();
        }

    }
}
