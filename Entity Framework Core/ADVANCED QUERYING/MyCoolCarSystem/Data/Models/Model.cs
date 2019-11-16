﻿namespace MyCoolCarSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Model;
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxModification)]
        public string Modification { get; set; }

        [Range(1900, 3000)]
        public int Year { get; set; }

        public int MakeId { get; set; }
        public Make Make { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
