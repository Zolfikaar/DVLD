using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User?> GetUserByPersonIdAsync(int personId);
        public Task<User?> GetUserByUsernameAsync(string username);
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<int> AddUserAsync(User user);
        public Task<bool> UpdateUserAsync(User user, int id);
        public Task<bool> DeleteUserAsync(int id);
        public Task<bool> IsActiveAsync(int id);
        public Task<bool> ActivateUserAsync(int id);
        public Task<bool> DeactivateUserAsync(int id);
    }
}