using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories
{
    public class TestTypeRepository : ITestTypeRepository
    {
        public TestTypeRepository()
        {
            CreateConnection();
        }
        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }
        public async Task<IEnumerable<TestType>> GetAllTestTypesAsync()
        {
            string query = "SELECT * FROM TestTypes";
            SqlConnection connection = CreateConnection();
            return await connection.QueryAsync<TestType>(query);
        }
        public async Task<bool> UpdateTestTypeAsync(int id, TestType testType)
        {
            string query = "UPDATE TestTypes SET " + "TestTypeTitle = @TestTypeTitle,TestTypeDescription = @TestTypeDescription, TestTypeFees = @TestTypeFees " + "WHERE TestTypeID = @TestTypeID";
            using var connection = CreateConnection();
            var parameters = new DynamicParameters(testType);
            parameters.Add("TestTypeID", id);
            var rowsEffected = await connection.ExecuteAsync(query, parameters);
            return rowsEffected > 0;
        }
        public async Task<TestType> GetTestTypeByIdAsync(int id)
        {
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TestType>(query, new { TestTypeID = id });
        }
    }
}
