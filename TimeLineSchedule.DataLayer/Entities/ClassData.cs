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
        [Display(Name ="نام گروه")]
        public string? Group { get; set; }
        [Display(Name = "روز برگزاری")]
        public DayOfWeek? DayOfClass { get; set; }
        [Display(Name = "زمان شروع")]
        public TimeOnly? ClassStart { get; set; }
        [Display(Name = "زمان پایان")]
        public TimeOnly? ClassEnd { get; set; }
        [Display(Name = "نام استاد")]
        public string? TeacherName { get; set; }
        [Display(Name = "شماره کلاس")]
        public int? ClassNum { get; set; }
        [Display(Name = "وضعیت تشکیل")]
        public bool? ClassStatus { get; set; }
        [Display(Name = "نام درس")]
        public string? ClassName { get; set; }
    }
}
