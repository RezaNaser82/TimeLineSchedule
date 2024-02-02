using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using TimeLineSchedule.Core.Helper;
using TimeLineSchedule.Core.Services.Interface;
using TimeLineSchedule.DataLayer.Context;
using TimeLineSchedule.DataLayer.Entities;

namespace TimeLineSchedule.Core.Services
{

    
    public class ExcelService : IExcelService
    {
        private readonly TimeLineContext _context;

        public ExcelService(TimeLineContext context)
        {
            _context = context;
        }

       

        public async Task ImportExcelData(IFormFile file)
        {
            var excelClassDataList = new List<ExcelClassDataModel>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    if (reader.Read()) 
                    {
                    }
                    int rowIndex = 0;

                    while (reader.Read()) 
                    {
                        try
                        {
                            var excelClassData = new ExcelClassDataModel
                            {
                                Group = reader.GetValue(0)?.ToString(),
                                DayOfClass = reader.GetValue(1)?.ToString(),
                                ClassStartTime = reader.GetDateTime(2), 
                                ClassEndTime = reader.GetDateTime(3), 
                                TeacherName = reader.GetValue(4)?.ToString(),
                                ClassNum = reader.GetValue(5)?.ToString(),
                                ClassSituation = reader.GetValue(6)?.ToString(),
                                ClassName = reader.GetValue(7)?.ToString(),
                                CourseId = reader.GetValue(8)?.ToString(),
                                ClassCode = reader.GetValue(9)?.ToString(),
                            };
                            excelClassDataList.Add(excelClassData);
                        }
                     
                    
                        catch (InvalidCastException ex)
                        {
                            throw new InvalidCastException($"Invalid cast on row {rowIndex}, Exception: {ex.Message}", ex);
                        }
                        catch (FormatException ex)
                        {
                            throw new FormatException($"Format issue on row {rowIndex}, Exception: {ex.Message}", ex);
                        }
                        rowIndex++;
                    }
                }
            }

            foreach (var excelModel in excelClassDataList)
            {
                if (!int.TryParse(excelModel.ClassNum, out int classNumParsed))
                {
                    
                    continue; 
                }
                var classData = new ClassData
                {
                    Group = excelModel.Group,
                    DayOfClass = ValueConverter.ParsePersianDayOfWeek(excelModel.DayOfClass),
                    ClassStart = ValueConverter.ParseTime(excelModel.ClassStartTime),
                    ClassEnd = ValueConverter.ParseTime(excelModel.ClassEndTime),
                    TeacherName = excelModel.TeacherName,
                    ClassNum = excelModel.ClassNum,
                    ClassStatus = ValueConverter.ParseClassSituation(excelModel.ClassSituation),
                    ClassName = excelModel.ClassName,
                    CourseId = Convert.ToInt32(excelModel.CourseId),
                    ClassCode = Convert.ToInt32(excelModel.ClassCode),
                };


                _context.ClassDatas.Add(classData);
            }

             _context.SaveChanges();

        }
        public async Task DeleteExcelData()
        {
            _context.ClassDatas.RemoveRange(_context.ClassDatas);
            _context.SaveChanges();
        }
        public async Task<bool> HasTableData()
        {
            return await _context.ClassDatas.AnyAsync();
        }
    }
}
                   
                    
        

               

        

