﻿namespace SoftJail.Data.Models
{

    using System.ComponentModel.DataAnnotations;

    public class Mail
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z 0-9]+ str.$")]
        public string Address { get; set; }

        [Required]
        //   [ForeignKey(nameof(Prisoner))]
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }

    }
}
