namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class ExportLocalCustomerDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public int CarSaleCount { get; set; }

        [XmlAttribute("spent-money")]
        public decimal CarSaleSum { get; set; }
    }
}
