using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.DTOs.ProjectDtos;
using Amnil.TaskManagement.Entities;
using Amnil.TaskManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Amnil.TaskManagement.Services
{
    [Authorize]
    public class ProjectService : ApplicationService, IProjectService, ITransientDependency
    {
        private readonly IRepository<Project, Guid> _projectRepository;
        public ProjectService(IRepository<Project, Guid> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateProjectAsync(CreateUpdateProjectDto createDto)
        {
            var project = new Project(name: createDto.Name, description: createDto.Description, startDate: createDto.StartDate, endDate: createDto.EndDate);
            await _projectRepository.InsertAsync(project);
        }

        public async Task DeleteProjectAsync(Guid projectId)
        {
            var project = await _projectRepository.GetAsync(projectId);
            await _projectRepository.DeleteAsync(project);
        }

        public async Task UpdateProjectAsync(Guid projectId, CreateUpdateProjectDto updateDto)
        {
            var project = await _projectRepository.GetAsync(projectId);
            project.Update(name: updateDto.Name, description: updateDto.Description, startDate: updateDto.StartDate, endDate: updateDto.EndDate);
            await _projectRepository.UpdateAsync(project);
        }
        public async Task<List<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetListAsync();
            return projects.Select(project => new ProjectDto(project)).ToList();
        }

        public async Task<ProjectDto> FindByIdAsync(Guid projectId)
        {
            var project = await _projectRepository.GetAsync(projectId);

            if (project == null) {
                return null;
            }
            return new ProjectDto(project);
        }

        //public async Task<ProjectProgressDto> GetProjectProgressDto(Guid projectId)
        //{
        //    var project = _projectRepository.GetAsync(projectId);
        //    var total = await _projectRepository.GetCountAsync();
        //}
    }
}
