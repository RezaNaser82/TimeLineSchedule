using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLineSchedule.Core.Helper
{
    public static class ValueConverter 
    { 
        //This Is For mapping from the excel
        public static DayOfWeek ParsePersianDayOfWeek(string persianDay)
        {
            var mapper = new Dictionary<string, DayOfWeek>
            {
                {"شنبه", DayOfWeek.Saturday},
                {"یکشنبه", DayOfWeek.Sunday},
                {"دوشنبه", DayOfWeek.Monday},
                {"سه شنبه", DayOfWeek.Tuesday},
                {"چهارشنبه", DayOfWeek.Wednesday},
                {"پنجشنبه", DayOfWeek.Thursday},
                {"جمعه", DayOfWeek.Friday},
            };

            return mapper.TryGetValue(persianDay, out var dayOfWeek) ? dayOfWeek
                : throw new ArgumentException("Invalid Persian day of the week.", nameof(persianDay));
        }
        public static TimeOnly ParseTime(object timeValue)
        {
            if (timeValue is DateTime dateTime)
            {
               
                return TimeOnly.FromDateTime(dateTime);
            }
            else if (timeValue is string timeString)
            {
                return TimeOnly.ParseExact(timeString, new[] { "H:mm", "HH:mm" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            else
            {
                throw new ArgumentException("Invalid time format. Expected either a DateTime object or a string in the format 'HH:mm'.");
            }
        }
        
        public static bool ParseClassSituation(string classSituation)
        {
            return classSituation == "تشکیل";
        }

        public static string ConvertToPersianDayOfWeek(DayOfWeek day)
        {
            string[] persianDayNames =
            {
        "یک‌شنبه",
        "دوشنبه",
        "سه‌شنبه",
        "چهارشنبه",
        "پنج‌شنبه",
        "جمعه",
        "شنبه"
    };

            return persianDayNames[(int)day];
        }
    }
}
