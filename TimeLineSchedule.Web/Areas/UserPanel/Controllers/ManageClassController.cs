using Hangfire.States;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "MainAdmin , SecondAdmin")]

    public class ManageClassController : Controller
    {
        private readonly IClassDataService _classDataService;
        private readonly ILogger _logger;
        public ManageClassController(IClassDataService classDataService, ILogger<HomeController> logger)
        {
            _classDataService = classDataService;
            _logger = logger;
        }
        [Route("admin")]
        public IActionResult Index()
        {
            var allClassData = _classDataService.GetAllClassData();
            return View(allClassData);
        }

        [HttpPost]
        public IActionResult Create(ClassData classData, string scheduledDate)
        {
            if (string.IsNullOrWhiteSpace(scheduledDate) || ModelState[nameof(scheduledDate)].Errors.Count > 0)
            {
                ModelState.Remove(nameof(scheduledDate));

                classData.ScheduledDate = DateTime.Today;
            }
            if (!string.IsNullOrWhiteSpace(scheduledDate))
            {
                classData.ScheduledDate = ConvertPersianToGregorian(scheduledDate) ?? DateTime.Today;
            }
            if (ModelState.IsValid)
            {
                _classDataService.CreateOrUpdateClassData(classData);
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Index), classData);
        }


        [HttpPost]
        public IActionResult Update(ClassData classData, string scheduledDate)
        {
            if (string.IsNullOrWhiteSpace(scheduledDate) || ModelState[nameof(scheduledDate)].Errors.Count > 0)
            {
                ModelState.Remove(nameof(scheduledDate));

                classData.ScheduledDate = DateTime.Today;
            }
            if (!string.IsNullOrWhiteSpace(scheduledDate))
            {
                classData.ScheduledDate = ConvertPersianToGregorian(scheduledDate) ?? DateTime.Today;
            }
            if (ModelState.IsValid)
            {
                _classDataService.CreateOrUpdateClassData(classData);
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Index), classData);
        }

        private DateTime? ConvertPersianToGregorian(string persianDate)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                string[] parts = persianDate.Split('/');
                if (parts.Length != 3)
                {
                    return null;
                }

                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);

                
                return persianCalendar.ToDateTime(year, month, day, 12, 0, 0, 0);
            }
            catch
            {
                
                return null;
            }
        }
    }
}