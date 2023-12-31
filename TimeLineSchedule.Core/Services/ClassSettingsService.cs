using Hangfire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services
{
    public class ClassSettingsService : IClassSettingsService
    {
        private readonly TimeLineContext _context;
        public ClassSettingsService(TimeLineContext context)
        {
            _context = context; 
        }
        public IEnumerable<SettingsModel> GetAllSettings()
        {
            return _context.settings.ToList();
        }
        public void UpdateClassSettings(SettingsModel settingsModel)
        {
            var existingSettinModel = _context.settings.Find(settingsModel.Id);
            if (existingSettinModel != null)
            {
                _context.Entry(existingSettinModel).CurrentValues.SetValues(settingsModel);
            }
            _context.SaveChanges();
        }        
        
    }
}
