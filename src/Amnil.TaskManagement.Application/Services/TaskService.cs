using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.DTOs;
using Amnil.TaskManagement.DTOs.ProjectDtos;
using Amnil.TaskManagement.Entities;
using Amnil.TaskManagement.Enums;
using Amnil.TaskManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Amnil.TaskManagement.Services
{
    [Authorize]
    public class TaskService : ApplicationService, ITaskService
    {
        private readonly IRepository<ProjectTask, Guid> _taskRepository;
        public TaskService(IRepository<ProjectTask, Guid> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> GetAllTasksAsync()
        {
            try
            {
                var tasks = await _taskRepository.GetListAsync();
                return tasks.Select(task => new TaskDto(task)).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while getting all tasks");
                throw;
            }
            
        }

        public async Task<TaskDto> FindByIdAsync(Guid taskId)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskId);
                if (task == null)
                {
                    return null;
                }
                return new TaskDto(task);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while getting requested task");
                throw;
            }
        }
        public async Task CreateTaskAsync(CreateUpdateTaskDto createDto)
        {
            try
            {
                var task = new ProjectTask(
                    name: createDto.Name,
                    description: createDto.Description,
                    status: new ProjectTaskStatus(),
                    priority: new Priority(),
                    userId: createDto.UserId,
                    projectId: createDto.ProjectId,
                    estimatedHours: createDto.EstimatedHours,
                    loggedHours: createDto.LoggedHours
                );

                await _taskRepository.InsertAsync(task);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating task");
                throw;
            }
        }
            
        public async Task UpdateTaskAsync(Guid taskId, CreateUpdateTaskDto updateDto)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskId);
                task.Update(
                    name: updateDto.Name,
                    description: updateDto.Description,
                    status: new ProjectTaskStatus(),
                    priority: new Priority(),
                    userId: updateDto.UserId,
                    projectId: updateDto.ProjectId,
                    estimatedHours: updateDto.EstimatedHours,
                    loggedHours: updateDto.LoggedHours);
                await _taskRepository.InsertAsync(task);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating task");
                throw;
            }
        }
        public async Task DeleteTaskAsync(Guid taskid)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskid);
                await _taskRepository.DeleteAsync(task);
            }
            catch( Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating task");
                throw;
            }
            
        }
        public async Task AssignTaskAsync(Guid taskId, Guid userId)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskId);
                task.AssignTo(userId);
                await _taskRepository.UpdateAsync(task, autoSave: true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while assigning task to user");
                throw;
            }
        }

        public async Task AddToProjectAsync(Guid taskId, Guid projectId)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskId);
                task.AddToProject(projectId);
                await _taskRepository.UpdateAsync(task, autoSave: true);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error occurred while adding task to project");
                throw;
            }
        }
        public async Task UpdateStatusAsync(Guid taskId, ProjectTaskStatus status)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskId);
                task.UpdateStatus(status);
                await _taskRepository.UpdateAsync(task, autoSave: true);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating status");
                throw;
            }
        }
        public async Task LogHoursAsync(Guid taskId, int hours)
        {
            try
            {
                var task = await _taskRepository.GetAsync(taskId);
                task.LogHours(hours);
                await _taskRepository.UpdateAsync(task, autoSave: true);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error occurred while assigning log hours");
                throw;
            }
        }


    }
}
