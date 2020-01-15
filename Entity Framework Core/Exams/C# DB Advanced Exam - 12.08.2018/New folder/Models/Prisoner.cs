﻿namespace SoftJail.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using System.Collections.Generic;
    
    public class Prisoner
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FullName { get; set; }
        
        [Required]
        [RegularExpression(@"^The [A-Z]{1}[a-z]+$")]
        public string Nickname { get; set; }
        
        [Required]
        [Range(18,65)]
        public int Age { get; set; }
       
        [Required]
        public DateTime IncarcerationDate { get; set; }

        public DataType? ReleaseDate { get; set; }
        
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }
        
        [ForeignKey(nameof(Cell))]
        public int CellId { get; set; }
        public Cell Cell { get; set; }

        public ICollection<Mail> Mails { get; set; } = new HashSet<Mail>();

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; } = new HashSet<OfficerPrisoner>();
    }
}