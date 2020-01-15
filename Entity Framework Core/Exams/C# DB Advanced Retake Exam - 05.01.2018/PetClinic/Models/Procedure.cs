namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Procedure
    {

        [Key]
        public int Id { get; set; }
        public decimal Cost => ProcedureAnimalAids.Sum(s => s.AnimalAid.Price);

        [Required]
        //[ForeignKey("AnimalId")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        [Required]
        //[ForeignKey("VetId")]
        public int VetId { get; set; }
        public Vet Vet { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new HashSet<ProcedureAnimalAid>();

        



        //-	Id – integer, Primary Key
        //-	AnimalId ¬– integer, foreign key
        //-	Animal – the animal on which the procedure is performed(required)
        //    -	VetId ¬– integer, foreign key
        //-	Vet – the clinic’s employed doctor servicing the patient(required)
        //    -	ProcedureAnimalAids – collection of type ProcedureAnimalAid
        //-	Cost – the cost of the procedure, calculated by summing the price of the different services performed; does not need to be inserted in the database
        //-	DateTime – the date and time on which the given procedure is performed(required)

    }
}
