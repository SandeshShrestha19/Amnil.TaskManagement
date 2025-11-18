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
        private readonly IRepository<ProjectTask, Guid> _taskRepository;
        public ProjectService(IRepository<Project, Guid> projectRepository, IRepository<ProjectTask, Guid> taskRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
        }

        public async Task CreateProjectAsync(CreateUpdateProjectDto createDto)
        {
            try
            {
                var project = new Project(name: createDto.Name, description: createDto.Description, startDate: createDto.StartDate, endDate: createDto.EndDate);
                await _projectRepository.InsertAsync(project);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating project");
                throw;
            }

        }

        public async Task DeleteProjectAsync(Guid projectId)
        {
            try
            {
                var project = await _projectRepository.GetAsync(projectId);
                await _projectRepository.DeleteAsync(project);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting project");
                throw;
            }

        }

        public async Task UpdateProjectAsync(Guid projectId, CreateUpdateProjectDto updateDto)
        {
            try
            {
                var project = await _projectRepository.GetAsync(projectId);
                project.Update(name: updateDto.Name, description: updateDto.Description, startDate: updateDto.StartDate, endDate: updateDto.EndDate);
                await _projectRepository.UpdateAsync(project);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating project");
                throw;
            }
            
        }
        public async Task<List<ProjectDto>> GetAllProjectsAsync()
        {
            try
            {
                var projects = await _projectRepository.GetListAsync();
                return projects.Select(project => new ProjectDto(project)).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while getting list of projects");
                throw;
            }

        }

        public async Task<ProjectDto> FindByIdAsync(Guid projectId)
        {
            try
            {
                var project = await _projectRepository.GetAsync(projectId);

                if (project == null)
                {
                    return null;
                }
                return new ProjectDto(project);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while getting project");
                throw;
            }

        }

        public async Task<ProjectProgressDto> GetProjectProgressAsync(Guid projectId)
        {
            try
            {
                var project = (await _taskRepository.GetQueryableAsync())
                 .Where(t => t.ProjectId == projectId);

                var total = await AsyncExecuter.CountAsync(project);
                var byStatus = await AsyncExecuter.ToListAsync(
                        project.GroupBy(t => t.Status)
                             .Select(g => new
                             {
                                 Status = g.Key,
                                 Count = g.Count()
                             }));
                var estimated = await AsyncExecuter.SumAsync(project, task => task.EstimatedHours);

                var logged = await AsyncExecuter.SumAsync(project, task => task.LoggedHours);

                return new ProjectProgressDto
                {
                    TotalTasks = total,
                    EstimatedHours = estimated,
                    LoggedHours = logged
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while getting progress report.");
                throw;
            }

        }
    }
}
