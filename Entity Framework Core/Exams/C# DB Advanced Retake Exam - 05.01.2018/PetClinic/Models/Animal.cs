namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }

        [Required]
        public string PassportSerialNumber { get; set; }
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();

 
    }
}
//-	Id – integer, Primary Key
//-	Name – text with min length 3 and max length 20 (required)
//-	Type – text with min length 3 and max length 20 (required)
//-	Age – integer, cannot be negative or 0 (required)
//-	PassportSerialNumber ¬– string, foreign key
//-	Passport – the passport of the animal(required)
//-	Procedures – the procedures, performed on the animal
