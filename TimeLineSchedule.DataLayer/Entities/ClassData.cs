using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLineSchedule.DataLayer.Entities
{
    public class ClassData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Group { get; set; }

        public DayOfWeek? DayOfClass { get; set; }
        public TimeOnly? ClassStart { get; set; }
        public TimeOnly? ClassEnd { get; set; }
        public string? TeacherName { get; set; }
        public string? ClassNum { get; set; }
        public bool? ClassStatus { get; set; }
        public string? ClassName { get; set; }
        public int? CourseId { get; set; }
        public int? ClassCode { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? ScheduledDate { get; set; }
    }
}
