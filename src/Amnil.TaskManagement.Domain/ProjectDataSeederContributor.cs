using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Amnil.TaskManagement
{
    public class ProjectDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Project, Guid> _projectRepository;

        public ProjectDataSeederContributor(IRepository<Project, Guid> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _projectRepository.GetCountAsync() <= 0)
            {
                var project = new Project(name: "Health Project", description: "Do something enjoyful and eat healthy",startDate: DateTime.UtcNow,endDate: new DateTime(2025, 12, 31));
                await _projectRepository.InsertAsync(project, autoSave: true);
            }
        }
    }
}
