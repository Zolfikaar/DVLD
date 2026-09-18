using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public CountryRepository() 
        {
            CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            const string query = "SELECT CountryID, CountryName FROM Countries";
            SqlConnection connection = CreateConnection();
            return await connection.QueryAsync<Country>(query);
        }
    }
}
