using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services.Interface
{
    public interface IClassDataService
    {
        IEnumerable<ClassData> GetAllClassData();
        ClassData GetClassDataById(int id);
        void CreateOrUpdateClassData(ClassData classData);
        public void DeleteNewClasses();
        public void ActivateClasses();

    }
}
