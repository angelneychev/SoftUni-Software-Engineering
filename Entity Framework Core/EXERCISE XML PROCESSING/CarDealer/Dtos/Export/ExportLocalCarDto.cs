using CarDealer.Dtos.Export;

namespace CarDealer
{
    using System.Xml.Serialization;
    
    [XmlType("car")]
    public class ExportLocalCarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportLocalCardPartDto[] Parts { get; set; }
    }
}
