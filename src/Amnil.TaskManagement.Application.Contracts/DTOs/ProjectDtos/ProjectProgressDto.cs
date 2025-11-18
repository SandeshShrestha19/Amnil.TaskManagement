using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnil.TaskManagement.DTOs.ProjectDtos
{
    public class ProjectProgressDto
    {
        public int TotalTasks { get; set; }
        public int EstimatedHours { get; set; }
        public int LoggedHours { get; set; }
        public double CompletionPercentage => TotalTasks > 0 ? (double)LoggedHours / EstimatedHours * 100 : 0;
    }
}
