using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.Enums;
using Microsoft.VisualBasic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Amnil.TaskManagement.Entities
{
    public class ProjectTask : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectTaskStatus Status { get; protected set; }
        public Priority Priority { get; protected set; }

        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public int EstimatedHours { get; set; }
        public int LoggedHours { get; set; }

        protected ProjectTask() { }

        public ProjectTask(string name, string description, ProjectTaskStatus status, Priority priority, Guid userId, Guid projectId, int estimatedHours, int loggedHours)
        {
            Name = name;
            Description = description;
            Status = status;
            Priority = priority;
            UserId = userId;
            ProjectId = projectId;
            EstimatedHours = estimatedHours;
            LoggedHours = loggedHours;
        }
        public void AssignTo(Guid userId)
        {
            UserId = userId;
        }
        public void AddToProject(Guid projectId)
        {

        }

        public void UpdateStatus(ProjectTaskStatus status)
        {
            Status = status;
        }

        public void LogHours(int hours)
        {
            LoggedHours += hours;
        }

        public void Update(string name, string description, Priority priority,Guid userId,Guid projectId, int estimatedHours, int loggedHours)
        {
            Name = name;
            Description = description;
            Priority = priority;
            EstimatedHours = estimatedHours;
            LoggedHours = loggedHours;
            UserId = userId;
            ProjectId = projectId;
        }
    }
}
