using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.Entities;

namespace Amnil.TaskManagement.DTOs.ProjectDtos
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CreateUpdateTaskDto> Tasks { get; set; } = new();

        public ProjectDto(Project project)
        {
            Name = project.Name;
            Description = project.Description;
            StartDate = project.StartDate;
            EndDate = project.EndDate;
        }
    }
}
