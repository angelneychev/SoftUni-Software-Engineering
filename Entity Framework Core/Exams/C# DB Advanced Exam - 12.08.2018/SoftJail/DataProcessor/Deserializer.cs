using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string ImportedDepartment = "Imported {0} with {1} cells";
        private const string ImportedPrisoner = "Imported {0} {1} years old";
        private const string ImportedOfficer = "Imported {0} ({1} prisoners)";


        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Department>  departments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto) || !departmentDto.Cells.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = AutoMapper.Mapper.Map<Department>(departmentDto);
                departments.Add(department);

                sb.AppendLine(string.Format(ImportedDepartment, department.Name, department.Cells.Count()));

            }

            context.AddRange(departments);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            StringBuilder sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                var prisoner = Mapper.Map<Prisoner>(prisonerDto);

                bool isValidPrisoner = IsValid(prisoner);
                bool isValidMails = prisoner.Mails.Any(m => IsValid(m) == false);

                if (isValidPrisoner == false || isValidMails == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(prisoner);

                sb.AppendLine(string.Format(ImportedPrisoner,
                    prisoner.FullName,
                    prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Officer> officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                bool isValidPosition = Enum.IsDefined(typeof(Position), officerDto.Position);
                bool isValidWeapon = Enum.IsDefined(typeof(Weapon), officerDto.Weapon);

                if (isValidPosition == false || isValidWeapon == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = Mapper.Map<Officer>(officerDto);
                bool isValidOfficer = IsValid(officer);

                if (isValidOfficer == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                officer.OfficerPrisoners = officerDto.Prisoners
                    .Select(p => new OfficerPrisoner { PrisonerId = p.Id })
                    .ToList();

                officers.Add(officer);

                sb.AppendLine(string.Format(ImportedOfficer,
                    officer.FullName,
                    officer.OfficerPrisoners.Count()));
            }
            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}