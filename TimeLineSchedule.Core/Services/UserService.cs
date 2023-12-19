using Microsoft.EntityFrameworkCore;
using Resume.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.Core.DTOs;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services
{
    public class UserService : IUserService
    {
        private readonly TimeLineContext _context;
        public UserService(TimeLineContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistUserName(string userName)
        {
            return await _context.Users.AnyAsync(c => c.UserName == userName);
        }

        public async Task<User> LogInUser(string userName, string password)
        {
            var Password = PasswordHelper.EncodePasswordMd5(password);
            return await _context.Users.Include(u => u.UserRole).SingleOrDefaultAsync(u => u.UserName == userName && u.Password == Password);
        }
    }
}
