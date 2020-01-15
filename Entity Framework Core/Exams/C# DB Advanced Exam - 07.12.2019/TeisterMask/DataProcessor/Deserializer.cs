using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ExportDto;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projects"));

            var projectsDto = (ImportProjectsDto[]) xmlSerializer.Deserialize(new StringReader(xmlString));

            var projects = new List<Project>();

            StringBuilder sb = new StringBuilder();

            foreach (var dto in projectsDto)
            {
                DateTime dateTime;
              //  var isValidateDueDate = DateTime.TryParse(dto.DueDate, out dateTime);

                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectDueDate = string.IsNullOrEmpty(dto.DueDate)
                    ? new DateTime?()
                    : DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var projectOpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = projectOpenDate,
                    //DueDate = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    DueDate = projectDueDate
                };

                foreach (var dtoTask in dto.Tasks)
                {

                    //var isValidOpenDate = DateTime.TryParseExact(dtoTask.OpenDate, "dd/MM/yyyy",
                    //    CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime);
                    //var isValidDueDate = DateTime.TryParseExact(dtoTask.DueDate, "dd/MM/yyyy",
                    //    CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime);
                    var taskOpenDate = DateTime.ParseExact(dtoTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(dtoTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var correctDate = true;

                    //•	task open date is before project open date or task due date is after project due date)
                    if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        correctDate = false;
                    }

                    if (!IsValid(dtoTask) || !correctDate)
                    {
                        sb.AppendLine($"{ErrorMessage}");
                        continue;
                    }
                    //if (!IsValid(dtoTask) || !isValidOpenDate || !isValidDueDate)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}
                    if (projectDueDate == null)
                    {
                        var dateOpenCompare =
                            DateTime.Compare(taskOpenDate, projectOpenDate);
                        //  task open date is before project open date
                        if (dateOpenCompare < 0)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    project.Tasks.Add(new Task
                    {
                        Name = dtoTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(dtoTask.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(dtoTask.LabelType)
                    });



                    //var isValidOpenDate = DateTime.TryParse(dtoTask.OpenDate, out dateTime);
                    //var isValidDueDate = DateTime.TryParse(dtoTask.DueDate, out dateTime);

                        //  task open date is before project open date
                       // or task due date is after project due date),

                }
                projects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            
            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Employee> employees = new List<Employee>();
            List<EmployeeTask> employeeTask = new List<EmployeeTask>();

            foreach (var dto in employeesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = dto.Username,
                    Phone = dto.Phone,
                    Email = dto.Email,
                };

                foreach (var dtoTask in dto.Tasks.Distinct())
                {
                    var isValidTask = context.Tasks.FirstOrDefault(t => t.Id == dtoTask);
                    if (isValidTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        TaskId = dtoTask
                    });
                    //employeeTask.Add( new EmployeeTask
                    //{
                    //    Employee = employee,
                    //    TaskId = dtoTask
                    //});
                }
                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}