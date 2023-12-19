
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLineSchedule.DataLayer.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        
        
        
        #region relation
        public virtual List<User> Users { get; set; }
        #endregion
    }
}
