using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLineSchedule.DataLayer.Entities
{
    public class SettingsModel
    {
        [Key] 
        public int Id { get; set; }
        public int RefreshTime { get; set; }
        public int ChangeBoxTime { get; set; }
    }
}
