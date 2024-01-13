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
        [Required(ErrorMessage = "وارد کردن نام رشته اجباری است")]
        public string Group { get; set; }
        [Required(ErrorMessage = "روز برگزاری را وارد کنید")]
        public DayOfWeek DayOfClass { get; set; }
        [Required(ErrorMessage = "ساعت شروع کلاس را وارد کنید")]
        public TimeOnly ClassStart { get; set; }
        [Required(ErrorMessage = "ساعت پایان کلاس را وارد کنید")]
        public TimeOnly ClassEnd { get; set; }
        [Required(ErrorMessage = "نام استاد را وارد کنید")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "مکان برگزاری کلاس را وارد کنید")]
        public string ClassNum { get; set; }
        public bool ClassStatus { get; set; }
        [Required(ErrorMessage = "  نام درس را وارد کنید")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "کد درس را وارد کنید")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = " کد کلاس را وارد کنید")]
        public int ClassCode { get; set; }
        public bool? IsNew { get; set; }
        [Required(ErrorMessage = "تاریخ انجام عملیات را وارد کنید")]
        public DateTime ScheduledDate { get; set; }
    }
}
