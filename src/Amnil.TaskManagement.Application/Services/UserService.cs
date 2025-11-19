using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Amnil.TaskManagement.DTOs;
using Amnil.TaskManagement.DTOs.Users;
using Amnil.TaskManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Amnil.TaskManagement.Services
{
    [Authorize]
    public class UserService : ApplicationService, ITransientDependency
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<ProjectTask, Guid> _taskRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ICurrentUser _currentUser;

        public UserService(IRepository<User, Guid> userRepository, IPasswordHasher<User> passwordHasher, IRepository<ProjectTask, Guid> taskRepository, ICurrentUser currentUser)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _taskRepository = taskRepository;
            _currentUser = currentUser;
        }

        public async Task RegisterUserAsync(RegisterUpdateUserDto registerDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(registerDto.Username))
                {
                    throw new Exception("Username is required");
                }
                    

                if (string.IsNullOrWhiteSpace(registerDto.Email))
                {
                    throw new Exception("Email is required");
                }

                if (string.IsNullOrWhiteSpace(registerDto.Password))
                {
                    throw new Exception("Password is required");
                }

                var user = new User(userName: registerDto.Username, email: registerDto.Email);
                user.Password = _passwordHasher.HashPassword(user, registerDto.Password);
                await _userRepository.InsertAsync(user);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error occurred while registering user");
                throw;
            }
        }

        public async Task UpdateUserAsync(Guid userId, RegisterUpdateUserDto updateDto)
        {
            try
            {
                if (updateDto == null)
                {
                    throw new UserFriendlyException("Invalid username or password.");
                }

                var user = await _userRepository.GetAsync(userId);
                user.Update(userName: updateDto.Username, password: updateDto.Password);
                await _userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating user info");
                throw;
            }

        }
        public async Task DeleteUserAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetAsync(userId);
                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }

                await _userRepository.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting user");
                throw;
            }

        }
        public async Task<string> LoginAsync(LoginDto input)
        {
            try
            {
                var user = await _userRepository.FindAsync(user => user.UserName == input.UserName);
                if (user == null)
                {
                    throw new UserFriendlyException("Invalid username or password.");
                }

                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, input.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    throw new UserFriendlyException("Invalid username or password.");
                }

                return "Login successful";
            }
            catch (Exception)
            {
                throw new UserFriendlyException("Could not login. Please try again!");
            }

        }
        [Authorize]
        public async Task<List<TaskDto>> GetMyTasksAsync()
        {
            try
            {
                if (!_currentUser.IsAuthenticated)
                {
                    throw new AbpAuthorizationException("User must be logged in to view tasks.");
                }

                var userId = _currentUser.Id;
                var tasks = await _taskRepository.GetListAsync(task => task.UserId == userId);

                return tasks.Select(task => new TaskDto(task)).ToList();
            }
            catch (Exception)
            {
                throw new UserFriendlyException("Could not retrieve tasks. Please try again!");
            }
        }
    }
}
