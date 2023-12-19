using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.Core.DTOs;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services.Interface
{
    public interface IUserService
    {
            Task<bool> IsExistUserName(string userName);
            Task AddUser(User user);
            Task<User> LogInUser(string userName, string password);
          

    }
}
