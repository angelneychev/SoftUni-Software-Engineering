using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TeisterMask.DataProcessor.ImportDto
{
    class ImportEmployeesDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Username { get; set; }

        //TODO VALIDATE Mail
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //TODO VALIDATE phone nuber

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }
        
        public List<int> Tasks { get; set; }

    }
}
