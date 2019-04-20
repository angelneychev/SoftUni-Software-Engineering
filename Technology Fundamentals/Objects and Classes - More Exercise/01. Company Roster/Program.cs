using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
//Objects and Classes - More Exercise
namespace _01._Company_Roster
{
    class Employee //promqna za test
    {
        public Employee(string name, double salary, string department)//8888
        {
            this.Name = name; //gtr
            this.Salary = salary;//rrww
            this.Department = department;//ress
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < number; i++)
            {
                string[] inputLine = Console.ReadLine().Split().ToArray();
                string name = inputLine[0];
                double salary = double.Parse(inputLine[1]);
                string department = inputLine[2];
                Employee employee = new Employee(name, salary, department)
                {
                    Name = name,
                    Salary = salary,
                    Department = department
                };
                employees.Add(employee);
            }

            var result = employees
                .GroupBy(x => x.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AvgSalary = g.Average(e => e.Salary)
                })
                .OrderByDescending(o => o.AvgSalary)
                .First();


            Console.WriteLine($"Highest Average Salary:" +
                                  $" {result.Department}");

            foreach (var employee in employees.Where(x => x.Department == result.Department).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }
}
