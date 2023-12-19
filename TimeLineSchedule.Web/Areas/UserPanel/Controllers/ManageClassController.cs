using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Update(ClassData classData)
        {
           
            if (classData == null)
            {
                return NotFound();
            }

           

            _classDataService.UpdateClassData(classData);
            return RedirectToAction(nameof(Index));
        }
    }
}