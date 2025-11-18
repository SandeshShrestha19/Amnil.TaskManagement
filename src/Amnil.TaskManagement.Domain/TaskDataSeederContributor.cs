using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.Entities;
using Amnil.TaskManagement.Enums;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Amnil.TaskManagement
{
    public class TaskDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<ProjectTask, Guid> _taskRepository;

        public TaskDataSeederContributor(IRepository<ProjectTask, Guid> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _taskRepository.GetCountAsync() <= 0)
            {
                var task = new ProjectTask(
                            name: "Run 30mins a day",
                            description: "Chase Usain Bolt",
                            status: ProjectTaskStatus.New,
                            priority: Priority.Important,
                            userId: new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                            projectId: new Guid("33355566-0000-0000-0000-000000000000"),
                            estimatedHours: 15,
                            loggedHours: 10
                        );
                await _taskRepository.InsertAsync(task, autoSave: true);
            }
        }
    }
}
