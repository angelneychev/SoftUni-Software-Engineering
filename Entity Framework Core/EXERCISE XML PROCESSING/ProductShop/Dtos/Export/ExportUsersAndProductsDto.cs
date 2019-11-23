namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class ExportUsersAndProductsDto
    {
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlArray(ElementName = "users")]
        public ExportUsersWithSoldProductsDto[] Users { get; set; }
    }
}
