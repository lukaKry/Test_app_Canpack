using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_app_consoleApp.Services;

namespace Test_app_consoleApp
{
    public class MyScheduler
    {
        public static void IntervalInDays(int hour, int min, double interval, Action task)
        {
            interval = interval * 24;
            try
            {
                if (hour > 24 || hour < 0 || min < 0 || min > 59 || interval < 0) throw new FormatException("Incorect date format");
                SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
            }
            catch ( Exception e )
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
