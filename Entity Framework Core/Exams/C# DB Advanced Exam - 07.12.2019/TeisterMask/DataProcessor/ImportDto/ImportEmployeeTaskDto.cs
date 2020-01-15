using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeTaskDto
    {
        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public int TaskId { get; set; }
    }
}