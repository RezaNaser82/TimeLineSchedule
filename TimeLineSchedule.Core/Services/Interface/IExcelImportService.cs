using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services.Interface
{
        public interface IExcelService
        {
        Task ImportExcelData(IFormFile file);
        Task DeleteExcelData();
        Task<bool> HasTableData();
    }
}


