﻿namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }
        
        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }


        [Required]
        [MinLength(3), MaxLength(20)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; } = new HashSet<Projection>();


    }
}
