using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeLineSchedule.Core.Services;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Entities;
using TimeLineSchedule.Web.Models;

namespace TimeLineSchedule.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassesService _classesService;

        public HomeController(ILogger<HomeController> logger , IClassesService classesService)
        {
            _logger = logger;
            _classesService = classesService;
        }

        public async Task<IActionResult> Index()
        {
            List<ClassData> classes = await _classesService.GetClassesForTodayAsync();
            return View(classes);
        }


    }
}
