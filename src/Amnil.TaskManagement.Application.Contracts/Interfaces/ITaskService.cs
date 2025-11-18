using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.DTOs;
using Volo.Abp.Application.Services;

namespace Amnil.TaskManagement.Interfaces
{
    public interface ITaskService : IApplicationService
    {
        Task<List<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> FindByIdAsync(Guid taskId);
        Task CreateTaskAsync(CreateUpdateTaskDto createDto);
        Task UpdateTaskAsync(Guid taskId, CreateUpdateTaskDto updateDto);
        Task DeleteTaskAsync(Guid taskId);
        Task AddToProjectAsync(Guid taskId, Guid projectId);
        Task AssignTaskAsync(Guid taskId, Guid userId);
        Task UpdateStatusAsync(Guid taskId, Enums.ProjectTaskStatus status);
        Task LogHoursAsync(Guid taskId, int hours);
    }
}
