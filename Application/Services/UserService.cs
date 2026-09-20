using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(MapToDto);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(id);
            return userEntity == null ? null : MapToDto(userEntity);
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var userEntity = await _userRepository.GetUserByUsernameAsync(username);
            return userEntity == null ? null : MapToDto(userEntity);
        }

        public async Task<UserDto> GetUserByPersonIdAsync(int personId)
        {
            var userEntity = await _userRepository.GetUserByPersonIdAsync(personId);
            return userEntity == null ? null : MapToDto(userEntity);
        }

        public async Task<UserDto> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            UserDto user = await GetUserByUsernameAsync(username.Trim());
            if (user == null)
                return null;

            if (!string.Equals(user.PasswordHash, password, StringComparison.Ordinal))
                return null;

            if (!user.IsActive)
                return null;

            return user;
        }

        public async Task<int> CreateUserAsync(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            User existingUsername = await _userRepository.GetUserByUsernameAsync(userDto.Username);
            if (existingUsername != null)
                throw new InvalidOperationException("This username is already taken.");

            User existingPerson = await _userRepository.GetUserByPersonIdAsync(userDto.PersonId);
            if (existingPerson != null)
                throw new InvalidOperationException("This person already has a user account.");

            return await _userRepository.AddUserAsync(MapToEntity(userDto));
        }

        public async Task<bool> UpdateUserAsync(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            User existingUsername = await _userRepository.GetUserByUsernameAsync(userDto.Username);
            if (existingUsername != null && existingUsername.Id != userDto.Id)
                throw new InvalidOperationException("This username is already taken.");

            return await _userRepository.UpdateUserAsync(MapToEntity(userDto), userDto.Id);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string newPassword, string currentPassword = null)
        {
            User userEntity = await _userRepository.GetUserByIdAsync(userId);
            if (userEntity == null)
                return false;

            if (!string.IsNullOrEmpty(currentPassword) &&
                !string.Equals(userEntity.PasswordHash, currentPassword, StringComparison.Ordinal))
            {
                return false;
            }

            userEntity.PasswordHash = newPassword;
            return await _userRepository.UpdateUserAsync(userEntity, userId);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<bool> IsActiveAsync(int id)
        {
            return await _userRepository.IsActiveAsync(id);
        }

        public async Task<bool> ActivateUserAsync(int id)
        {
            return await _userRepository.ActivateUserAsync(id);
        }

        public async Task<bool> DeactivateUserAsync(int id)
        {
            return await _userRepository.DeactivateUserAsync(id);
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                PersonId = user.PersonId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                IsActive = user.IsActive,
                FullName = string.IsNullOrWhiteSpace(user.FullName) ? string.Empty : user.FullName.Replace("  ", " ").Trim(),
                IsActiveText = user.IsActive ? "Yes" : "No"
            };
        }

        private static User MapToEntity(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                PersonId = userDto.PersonId,
                Username = userDto.Username,
                PasswordHash = userDto.PasswordHash,
                IsActive = userDto.IsActive
            };
        }
    }
}
