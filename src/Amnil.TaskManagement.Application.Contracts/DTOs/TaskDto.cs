using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.Enums;

namespace Amnil.TaskManagement.DTOs
{
    public class TaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectTaskStatus Status { get; protected set; }
        public Priority Priority { get; protected set; }

        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public int EstimatedHours { get; set; }
        public int LoggedHours { get; set; }
    }
}
