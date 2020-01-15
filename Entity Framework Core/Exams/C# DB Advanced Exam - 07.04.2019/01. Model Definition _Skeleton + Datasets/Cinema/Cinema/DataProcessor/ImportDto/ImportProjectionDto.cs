using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [XmlElement("MovieId")]
        [Required] public int MovieId { get; set; }

        [XmlElement("HallId")]
        [Required] public int HallId { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }
    }
}
