using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.DataLayer.FluentApi.Settings
{
    public class SettingConfiguration : IEntityTypeConfiguration<SettingsModel>
    {
        public void Configure(EntityTypeBuilder<SettingsModel> builder)
        {
            builder.ToTable("settings");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
            builder.Property(s => s.RefreshTime).HasColumnType("int").IsRequired();
            builder.Property(s => s.ChangeBoxTime).HasColumnType("int").IsRequired();
            builder.HasData(new SettingsModel()
            {
               Id =1 , 
               RefreshTime = 1 , //minute
               ChangeBoxTime = 10 , // Second
            });
        }
    }
}
