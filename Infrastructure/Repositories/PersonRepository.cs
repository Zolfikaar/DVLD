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
    public class PersonRepository : IPersonRepository
    {

        public PersonRepository()
        {
            CreateConnection();
        }


        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        public async Task<Person?> GetByPersonIdAsync(int personId)
        {
            const string query = "SELECT * FROM People WHERE PersonID = @personId";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Person>(query, new { personId = personId });
        }

        public async Task<Person?> GetByNationalNoAsync(string nationalNo)
        {
            const string query = "SELECT FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address FROM People WHERE NationalNo = @nationalNo";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Person>(query, new { NationalNo = nationalNo });
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            const string query = "SELECT * FROM People"; // ORDER BY PersonalId DESC
            SqlConnection connection = CreateConnection();
            return await connection.QueryAsync<Person>(query);
        }

        public async Task<int> AddAsync(Person person)
        {
            const string query = @"
                INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = CreateConnection();
            // فتح الاتصال صراحةً للتأكد من عدم وجود Connection null
            await connection.OpenAsync();
            return await connection.ExecuteScalarAsync<int>(query, person);
        }

        public async Task<bool> UpdateAsync(Person updatedPerson, int currentPersonID)
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
                WHERE PersonID = @currentPersonID";
                

            using var connection = CreateConnection();

            var parameters = new DynamicParameters(updatedPerson);
            parameters.Add("currentPersonID", currentPersonID);

            var rowsEffected = await connection.ExecuteAsync(query, parameters);
            return rowsEffected > 0;
        }

        public async Task<bool> DeleteAsync(int personId)
        {
            const string query = "DELETE FROM People WHERE PersonID = @personId";
            using var connection = CreateConnection();
            var rowsEffected = await connection.ExecuteAsync(query, new { personId = personId });
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
