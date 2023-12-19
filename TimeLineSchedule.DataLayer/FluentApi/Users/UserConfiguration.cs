using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeLineSchedule.DataLayer.FluentApi.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
            builder.Property(u => u.UserName).HasColumnType("nvarchar(100)").IsRequired();
            builder.HasAlternateKey(u => u.UserName);
            builder.Property(u => u.RoleId).HasColumnType("int").IsRequired();
            builder.Property(u => u.Password).HasColumnType("varchar(100)").IsRequired();
        }
        
    }    
}
