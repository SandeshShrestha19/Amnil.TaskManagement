using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.Enums;

namespace Amnil.TaskManagement.DTOs
{
    public class CreateUpdateTaskDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public ProjectTaskStatus Status { get; protected set; }
        [Required]
        public Priority Priority { get; protected set; }
        [Required]

        public Guid UserId { get; set; }
        [Required]
        public Guid ProjectId { get; set; }
        public int EstimatedHours { get; set; }
        public int LoggedHours { get; set; }
    }
}
