using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Amnil.TaskManagement.Entities
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        protected Project() { }

        public Project(string name, string description, DateTime? startDate, DateTime? endDate)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public void Update(string name, string description, DateTime? startDate, DateTime? endDate)
        {
            Name = name;
            Description = description;
            StartDate = start;
            EndDate = end;
        }
    }
}
