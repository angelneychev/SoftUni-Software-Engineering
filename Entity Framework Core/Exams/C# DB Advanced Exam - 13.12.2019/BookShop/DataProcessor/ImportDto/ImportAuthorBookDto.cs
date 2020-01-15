using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorBookDto
    {
        [Required]
        public int BookId { get; set; }
    }
}