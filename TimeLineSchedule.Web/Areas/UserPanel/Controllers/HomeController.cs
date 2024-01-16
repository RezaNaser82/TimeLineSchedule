using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using TimeLineSchedule.Core.DTOs;
using TimeLineSchedule.Core.Helper;
using TimeLineSchedule.Core.Services;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;

using TimeLineSchedule.Web.Models;

namespace TimeLineSchedule.Web.Areas.UserPanel.Controllers
{

    [Area("UserPanel")]
    [Authorize(Roles = "MainAdmin")]
    public class HomeController : Controller
    {
        private readonly IExcelService _excelService;
        private readonly ILogger _logger;



        public HomeController(IExcelService excelService, ILogger<HomeController> logger )
        {
            _excelService = excelService;  
            _logger = logger;
           
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("فایلی انتخاب نشده است.");
            }

            try
            {
                await _excelService.ImportExcelData(file);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while importing the Excel data. Request ID: {RequestId}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

              
                ModelState.AddModelError(string.Empty, "An error occurred while importing data, please try again.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> ClearTable()
        {
            await _excelService.DeleteExcelData();

            return RedirectToAction("Index"); 
        }
        
    }
}

        
         
