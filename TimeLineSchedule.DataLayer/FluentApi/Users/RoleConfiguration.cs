using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.DataLayer.FluentApi.Users
{
    public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
            builder.Property(u => u.RoleName).HasColumnType("nvarchar(100)").IsRequired();
            builder.HasAlternateKey(u => u.RoleName);
            builder.HasData(new UserRole()
            {
                Id = 1,
                RoleName = "MainAdmin",
            });
            builder.HasData(new UserRole()
            {
                Id = 2,
                RoleName = "SecondAdmin",
            });
            builder.HasData(new UserRole()
            {
                Id = 3,
                RoleName = "ExcelAdmin",
            });
            builder.HasData(new UserRole()
            {
                Id = 4,
                RoleName = "RegularUser",
            });
        }
    }
}
