using System.Collections.Generic;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

#nullable enable

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string UserSelect = @"
            SELECT
                u.UserID AS Id,
                u.PersonID AS PersonId,
                u.UserName AS Username,
                u.Password AS PasswordHash,
                u.IsActive,
                LTRIM(RTRIM(
                    ISNULL(p.FirstName, '') + ' ' +
                    ISNULL(p.SecondName, '') + ' ' +
                    ISNULL(p.ThirdName, '') + ' ' +
                    ISNULL(p.LastName, '')
                )) AS FullName
            FROM Users u
            LEFT JOIN People p ON u.PersonID = p.PersonID";

        public UserRepository()
        {
            CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            string query = UserSelect + " WHERE u.UserID = @userId";
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { userId });
            }
        }

        public async Task<User?> GetUserByPersonIdAsync(int personId)
        {
            string query = UserSelect + " WHERE u.PersonID = @personId";
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { personId });
            }
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            string query = UserSelect + " WHERE u.UserName = @username";
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { username });
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<User>(UserSelect);
            }
        }

        public async Task<int> AddUserAsync(User user)
        {
            const string query = @"
                INSERT INTO Users (PersonID, UserName, Password, IsActive)
                VALUES (@PersonId, @Username, @PasswordHash, @IsActive);
                SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<int>(query, user);
            }
        }

        public async Task<bool> UpdateUserAsync(User user, int id)
        {
            const string query = @"
                UPDATE Users
                SET PersonID = @PersonId,
                    UserName = @Username,
                    Password = @PasswordHash,
                    IsActive = @IsActive
                WHERE UserID = @Id";
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                user.Id = id;
                int affectedRows = await connection.ExecuteAsync(query, user);
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            const string query = "DELETE FROM Users WHERE UserID = @userId";
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                int affectedRows = await connection.ExecuteAsync(query, new { userId });
                return affectedRows > 0;
            }
        }

        public async Task<bool> IsActiveAsync(int userId)
        {
            const string query = "SELECT IsActive FROM Users WHERE UserID = @userId";
            using (var connection = CreateConnection())
            {
                bool? isActive = await connection.QueryFirstOrDefaultAsync<bool?>(query, new { userId });
                return isActive ?? false;
            }
        }

        public async Task<bool> ActivateUserAsync(int userId)
        {
            const string query = "UPDATE Users SET IsActive = 1 WHERE UserID = @userId";
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                int affectedRows = await connection.ExecuteAsync(query, new { userId });
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            const string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @userId";
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                int affectedRows = await connection.ExecuteAsync(query, new { userId });
                return affectedRows > 0;
            }
        }
    }
}
