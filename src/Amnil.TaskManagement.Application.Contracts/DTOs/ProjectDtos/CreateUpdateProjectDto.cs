using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amnil.TaskManagement.DTOs.ProjectDtos
{
    public class CreateUpdateProjectDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
