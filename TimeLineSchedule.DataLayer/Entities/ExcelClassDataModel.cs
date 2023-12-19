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
        public string DayOfClass { get; set; } // Persian Weekday in Excel
        public DateTime ClassStartTime { get; set; } // Time as string in Excel
        public DateTime ClassEndTime { get; set; } // Time as string in Excel
        public string TeacherName { get; set; }
        public string ClassNum { get; set; } // Changed from int to string
        public string ClassSituation { get; set; } // تشکیل or لغو in Excel
        public string ClassName { get; set; }
    }
}
