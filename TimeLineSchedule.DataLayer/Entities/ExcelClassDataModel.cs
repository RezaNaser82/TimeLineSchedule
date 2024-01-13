using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLineSchedule.DataLayer.Entities
{
    public class ExcelClassDataModel
    {
        public string Group { get; set; }
        public string DayOfClass { get; set; } 
        public DateTime ClassStartTime { get; set; }
        public DateTime ClassEndTime { get; set; }
        public string TeacherName { get; set; }
        public string ClassNum { get; set; }
        public string ClassSituation { get; set; }
        public string ClassName { get; set; }
        public string CourseId { get; set; }
        public string ClassCode { get; set; }
    }
}
