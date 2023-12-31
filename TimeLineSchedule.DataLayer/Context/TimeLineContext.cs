
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Entities;
using TimeLineSchedule.DataLayer.FluentApi.Settings;
using TimeLineSchedule.DataLayer.FluentApi.Users;

namespace TimeLineSchedule.DataLayer.Context
{
    public class TimeLineContext : DbContext
    {
        public TimeLineContext(DbContextOptions<TimeLineContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<ClassData> ClassDatas { get; set; }
        public DbSet<SettingsModel> settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
