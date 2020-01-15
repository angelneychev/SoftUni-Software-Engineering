using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    class ImportDepartmentDto
    {
        [MinLength(3), MaxLength(25), Required]
        public string Name { get; set; }

        public ImportCellDto[] Cells { get; set; }
    }
}
