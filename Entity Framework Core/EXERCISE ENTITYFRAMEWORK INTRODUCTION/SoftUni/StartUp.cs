using System;
using System.Globalization;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //string result = GetEmployeesFullInformation(context);
            // string result = GetEmployeesWithSalaryOver50000(context);
            // string result = GetEmployeesFromResearchAndDevelopment(context);
            //string result = AddNewAddressToEmployee(context);
            // string result = GetEmployeesInPeriod(context);
            // string result = GetAddressesByTown(context);
            //string result = GetEmployee147(context);
            // string result = GetDepartmentsWithMoreThan5Employees(context);
            // string result = GetLatestProjects(context);
             string result = IncreaseSalaries(context);
            // string result = GetEmployeesByFirstNameStartingWithSa(context);
             //  string result = RemoveTown(context);



            Console.WriteLine(result);
        }
        //3.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = String.Join(" ", e.FirstName, e.LastName, e.MiddleName), e.JobTitle, e.Salary
                });

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //4.Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new
                {
                    Name = e.FirstName,
                    Salary = e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.Name);
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Name} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }
        //5.Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    DepartnentName = e.Department.Name,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary

                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartnentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //6.Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressTexts = context
                .Employees
                .OrderByDescending(e => e.Address)
                .Select(e => new {e.Address.AddressText})
                .Take(10)
                .ToList();

            foreach (var at in addressTexts)
            {
                sb.AppendLine(at.AddressText);
            }

            return sb.ToString().TrimEnd();

        }
        //7.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            StartDate = p.Project.StartDate,
                            EndDate = p.Project.EndDate
                        })
                        .ToList()
                })
                .Take(10)
                .ToList();


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.EmployeeName} - Manager: {e.ManagerName}");

                foreach (var p in e.Projects)
                {
                    var startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = p.EndDate == null ? "not finished" : p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }
        //8.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town,
                    EmployeesCount = a.Employees.Count()
                })
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
        //9.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee = context
                .Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Lastname = e.LastName,
                    JobTitle = e.JobTitle,
                    ProjectName = e.EmployeesProjects
                        .Select(p => new
                        {
                            Name = p.Project.Name
                        })
                        .OrderBy(p => p.Name)
                        .ToList()
                })
                .ToList();
            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.Lastname} - {e.JobTitle}");
                foreach (var p in e.ProjectName)
                {
                    sb.AppendLine($"{p.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //10.Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            JobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToList()
                })
                .ToList();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.EmployeeLastName} {e.EmployeeFirstName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var Project = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                })
                .ToList();
            foreach (var p in Project)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();

        }
        //12.Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeSalaries = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employeeSalaries)
            {
                employee.Salary += employee.Salary * (decimal)0.12;
                context.SaveChanges();
            }

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
        //13.Find Employees by First Name Starting With "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
        //14.Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var targetProject = context
                .Projects
                .FirstOrDefault(p => p.ProjectId == 2);
            var targetProjectEmployee = context
                .EmployeesProjects.FirstOrDefault(e => e.ProjectId == 2);
            context.EmployeesProjects.Remove(targetProjectEmployee);
            context.Projects.Remove(targetProject);
            var project = context
                .Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10)
                .ToList();
            foreach (var p in project)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }
        //15.Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();
            foreach (var e in employees)
            {
                e.AddressId = null;
                context.SaveChanges();
            }

            var towns = context
                .Towns
                .Where(t => t.Name == "Seattle")
                .ToList();
            var addresses = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();
            int countAdress = addresses.Count;
            foreach (var a in addresses)
            {
                context.Addresses.Remove(a);
                context.SaveChanges();
            }

            foreach (var t in towns)
            {
                context.Towns.Remove(t);
                context.SaveChanges();
            }

            return ($"{countAdress} addresses in Seattle were deleted");
        }
    }
}
