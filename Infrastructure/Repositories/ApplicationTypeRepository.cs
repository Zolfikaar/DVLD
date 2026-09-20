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
    public class ApplicationTypeRepository : IApplicationTypeRepository
    {
        public ApplicationTypeRepository()
        {
            CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        public async Task<IEnumerable<ApplicationType>> GetAllApplicationTypesAsync()
        {
            string query = "SELECT * FROM ApplicationTypes";
            SqlConnection connection = CreateConnection();
            return await connection.QueryAsync<ApplicationType>(query);
        }

        public async Task<bool> UpdateApplicationTypeAsync(int id, ApplicationType applicationType)
        {
            string query = "UPDATE ApplicationTypes SET " + "ApplicationTypeTitle = @ApplicationTypeTitle, ApplicationFees = @ApplicationFees " + "WHERE ApplicationTypeID = @ApplicationTypeID";

            using var connection = CreateConnection();

            var parameters = new DynamicParameters(applicationType);
            parameters.Add("ApplicationTypeID", id);

            var rowsEffected = await connection.ExecuteAsync(query, parameters);
            return rowsEffected > 0;
        }

        public async Task<ApplicationType> GetApplicationTypeByIdAsync(int id)
        {
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ApplicationType>(query, new { ApplicationTypeID = id });
        }
    }
}
