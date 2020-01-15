using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [XmlElement("Name")]
        [MinLength(3), MaxLength(30), Required]
        public string FullName { get; set; }

        [XmlElement("Money")]
        [Range(0, double.MaxValue), Required]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        public ImportPrisonerIdDto[] Prisoners { get; set; }

    }
}
