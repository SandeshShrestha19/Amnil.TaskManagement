using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amnil.TaskManagement.DTOs;
using Amnil.TaskManagement.DTOs.Users;
using Volo.Abp.Application.Services;

namespace Amnil.TaskManagement.Interfaces
{
    public interface IUserService : IApplicationService
    {
        Task RegisterUserAsync(RegisterUpdateUserDto registerDto);
        Task UpdateUserAsync(Guid userId, RegisterUpdateUserDto updateDto);
        Task DeleteUserAsync(Guid userId);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<List<TaskDto>> GetMyTasksAsync();

    }
}
