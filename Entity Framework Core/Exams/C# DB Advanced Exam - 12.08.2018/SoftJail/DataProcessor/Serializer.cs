using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace SoftJail.DataProcessor
{

    using Data;
    using SoftJail.Data.Models;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(x=>ids.Contains(x.Id))
                .OrderBy(x=>x.FullName)
                .Select(x=> new
                {
                    x.Id,
                    Name = x.FullName,
                    x.Cell.CellNumber,
                    OfOfficers = x.PrisonerOfficers
                        .Select(op=> new
                        {
                            OfficerName = op.Officer.FullName,
                            Department = op.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(op => op.Officer.Salary)
                })
                .OrderBy(p => p.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {

            var name = prisonersNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(p => name.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(x => new ExportPrisonersByCellsDto
                {
                    
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString(@"yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(m => new ExportEncryptedMessageDto
                        {
                            Description = Reverse(m.Description)
                        })
                        .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonersByCellsDto[]), new XmlRootAttribute("Prisoners"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }
        private static string Reverse(string description)
        {
            char[] charArray = description.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
}
}