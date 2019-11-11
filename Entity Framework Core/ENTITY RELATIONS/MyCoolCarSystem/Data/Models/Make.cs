namespace MyCoolCarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using static DataValidations.Make;

    public class Make
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; } = new HashSet<Model>();
    }
}
