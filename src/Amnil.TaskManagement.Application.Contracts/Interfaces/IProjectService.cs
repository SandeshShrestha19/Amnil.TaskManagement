using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.DTOs.ProjectDtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Amnil.TaskManagement.Interfaces
{
    public interface IProjectService : IApplicationService
    {
        //Task<ProjectProgressDto> GetProjectProgressAsync(Guid projectId);
        Task CreateProjectAsync(CreateUpdateProjectDto createDto);
        Task UpdateProjectAsync(Guid projectId, CreateUpdateProjectDto updateDto);
        Task DeleteProjectAsync(Guid projectId);

        Task<List<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto> FindByIdAsync(Guid projectId);
    }
}
