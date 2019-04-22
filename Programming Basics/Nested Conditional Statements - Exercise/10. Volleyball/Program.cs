using System;

namespace _10._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string years = Console.ReadLine();
            var holidays = int.Parse(Console.ReadLine());
            var weekendsHome = int.Parse(Console.ReadLine());

            double sofiqWeekends = 48 - weekendsHome;
            double sofiaPlay = sofiqWeekends * 3.0 / 4;
            double sofiaHolidaysPlay = holidays * 2.0 / 3;
            double totalPlay = sofiaPlay + sofiaHolidaysPlay + weekendsHome;

            if (years == "leap")
            {
                totalPlay = Math.Floor(totalPlay + (totalPlay * 0.15));
            }
            else if (years == "normal")
            {
                totalPlay = Math.Floor(totalPlay);
            }
            Console.WriteLine(totalPlay);
        }
    }
}
