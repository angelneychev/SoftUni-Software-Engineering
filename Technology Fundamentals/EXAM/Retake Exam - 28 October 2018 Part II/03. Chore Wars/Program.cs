using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            //  int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            string pattern = @"(\<(?<dishes>([a-z0-9]*))\>)|(\[(?<cleaning>([A-Z0-9]*))\])|(\{(?<laundry>([\W\w\d]*))\})";
            int timeDishes = 0;
            int timeCleaning = 0;
            int timeLaundry = 0;
            while (input != "wife is happy")
            {

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string dishes = match.Groups["dishes"].Value;
                    string cleaning = match.Groups["cleaning"].Value;
                    string caundry = match.Groups["laundry"].Value;
                    if (dishes != string.Empty)
                    {
                        //  string dishes = match.Groups["dishes"].Value;
                        foreach (var dish in dishes)
                        {
                            if (char.IsDigit(dish))
                            {
                                int a = int.Parse(dish.ToString());

                                timeDishes += a;
                            }
                        }
                    }
                    else if (cleaning != string.Empty)
                    {
                        //  string cleaning = match.Groups["cleaning"].Value;
                        foreach (var clean in cleaning)
                        {
                            if (char.IsDigit(clean))
                            {
                                int a = int.Parse(clean.ToString());

                                timeCleaning += a;
                            }
                        }
                    }
                    else if (caundry != string.Empty)
                    {
                        // string caundry = match.Groups["laundry"].Value;
                        foreach (var caun in caundry)
                        {
                            if (char.IsDigit(caun))
                            {
                                int a = int.Parse(caun.ToString());

                                timeLaundry += a;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            int totalMinutes = timeLaundry + timeCleaning + timeDishes;

            Console.WriteLine($"Doing the dishes - {timeDishes} min.");
            Console.WriteLine($"Cleaning the house - {timeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {timeLaundry} min.");
            Console.WriteLine($"Total - {totalMinutes} min.");
        }
    }
}