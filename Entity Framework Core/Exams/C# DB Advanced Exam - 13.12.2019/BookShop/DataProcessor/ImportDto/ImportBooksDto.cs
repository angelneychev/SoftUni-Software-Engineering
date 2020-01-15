using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBooksDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Price")]
        //TODO - не е ясно дали не трябва да е null ? 
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        //TODO - не е ясно дали не трябва да е null ? 
        [Range(50, 5000)]
        public int Pages { get; set; }
       
        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}

//<Books>
//<Book>
//<Name>Hairy Torchwood</Name>
//<Genre>3</Genre>
//<Price>41.99</Price>
//<Pages>3013</Pages>
//<PublishedOn>01/13/2013</PublishedOn>
//</Book>
//<Book>
