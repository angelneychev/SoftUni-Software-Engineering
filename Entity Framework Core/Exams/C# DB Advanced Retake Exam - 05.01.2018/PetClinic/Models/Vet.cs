﻿namespace PetClinic.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Profession { get; set; }
        
        [Required]
        [Range(22, 65)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        public string PhoneNumber{ get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();


    }
}
