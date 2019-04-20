using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeOne = int.Parse(Console.ReadLine());
            int employeeTwo = int.Parse(Console.ReadLine());
            int employeeThree = int.Parse(Console.ReadLine());

            int numberOfSudant = int.Parse(Console.ReadLine());

            int sumAllEmployee = (employeeOne + employeeTwo + employeeThree); // обработват за един час
            int time = 0;
            int temp = numberOfSudant / sumAllEmployee;


            while (numberOfSudant > 0)
            {

                time++;
                if (time % 4 == 0)
                {
                    continue;
                }
                else
                {
                    numberOfSudant -= sumAllEmployee;
                }

            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
