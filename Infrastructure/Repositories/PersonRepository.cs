using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Domain.Interfaces;
using System.Data;
using Domain.Entities;
using Dapper;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;
        public PersonRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<Person?> GetByPersonalIdAsync(int personId)
        {
            const string query = @"SELECT FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address 
                            From People Where PersonalId = @personId";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Person>(query, new { PersonalId = personId });
        }

        public async Task<Person?> GetByNationalNoAsync(string nationalNo)
        {
            const string query = "SELECT FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address FROM People WHERE NationalNo = @nationalNo";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Person>(query, new { NationalNo = nationalNo });
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            const string query = "SELECT * FROM People ORDER BY PersonID DESC";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Person>(query);
        }

        public async Task<int> AddAsync(Person person)
        {
            const string query = @"
                INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query, person);
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            const string query = @"
                UPDATE People 
                SET NationalNo = @NationalNo,
                    FirstName = @FirstName,
                    SecondName = @SecondName,
                    ThirdName = @ThirdName,
                    LastName = @LastName,
                    DateOfBirth = @DateOfBirth,
                    Gender = @Gender,
                    Address = @Address,
                    Phone = @Phone,
                    Email = @Email,
                    NationalityCountryID = @NationalityCountryID,
                    ImagePath = @ImagePath
                WHERE PersonID = @PersonID";
                

            using var connection = CreateConnection();
            var rowsEffected = await connection.ExecuteAsync(query, person);
            return rowsEffected > 0;
        }

        public async Task<bool> DeleteAsync(int personalId)
        {
            const string query = "DELETE FROM People WHERE PersonalId = personalId";
            using var connection = CreateConnection();
            var rowsEffected = await connection.ExecuteAsync(query, personalId);
            return rowsEffected > 0;
        }

        public async Task<bool> IsExistsAsync(int personalId)
        {
            const string query = "SELECT * FROM People WHERE PersonalId = personalId";
            using var connection = CreateConnection();
            var rowsEffected = await connection.ExecuteAsync(query, personalId);
            return rowsEffected > 0;
        }

        public async Task<bool> IsExistsAsync(string nationalNo) 
        {
            const string query = "SELECT * FROM People WHERE NationalNo = nationalNo";
            using var connection = CreateConnection();
            var rowsEffected = await connection.ExecuteAsync(query, nationalNo);
            return rowsEffected > 0;
        }

    }
}
