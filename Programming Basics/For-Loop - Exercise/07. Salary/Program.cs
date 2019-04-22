using System;

namespace _07._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberTabs; i++)
            {
                string webSite = Console.ReadLine();
                if (webSite == "Facebook")
                {
                    salary -= 150;
                }
                else if (webSite == "Instagram")
                {
                    salary -= 100;
                }
                else if (webSite == "Reddit")
                {
                    salary -= 50;
                }
                else
                {
                    salary += 0;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
