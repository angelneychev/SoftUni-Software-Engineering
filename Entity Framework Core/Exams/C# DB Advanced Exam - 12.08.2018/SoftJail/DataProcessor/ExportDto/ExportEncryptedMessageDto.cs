namespace SoftJail.DataProcessor
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class ExportEncryptedMessageDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
