namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUsersWithSoldProductsDto
    {
        [XmlElement( "firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement(ElementName = "SoldProducts")]
        public ExportSoldProductsCountDto SoldProducts { get; set; }
    }
}
