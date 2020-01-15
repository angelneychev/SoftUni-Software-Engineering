﻿using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enum;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"\d{4} \d{4} \d{4} \d{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"\d{3}")]
        public string CVC { get; set; }

        [Required]
        public CardType Type { get; set; }
    }
}
