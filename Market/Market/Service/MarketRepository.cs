using Dapper;
using Market.Models.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Service
{
    public class MarketRepository : IMarketRepository
    {

        private string _connectionString;

        public MarketRepository(IOptions<DatabaseConfig> config)
        {
            _connectionString = config.Value.ConnectionStrings; 
        }
        
        public async Task<bool> DeleteSelectedPurse(int ProductId)
        {
            var query = @"DELETE FROM Purses WHERE ProductId = @ProductId;";


            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(query, new { ProductId });
                    return true;
                }
                catch
                {

                    return false;
                }
            }
        }

        public async Task<bool> InsertPurses(PursesDBO model)
        {
            var queryString = @$"INSERT INTO Purses (PurseName, Brand, Color, Price, Description) 
                                VALUES(@{nameof(PursesDBO.PurseName)}, @{nameof(PursesDBO.Brand)}, @{nameof(PursesDBO.Color)}, @{nameof(PursesDBO.Price)}, @{nameof(PursesDBO.Description)});";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(queryString, model);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<IEnumerable<PursesDBO>> SelectAllPurses()
        {
            const string queryString = "Select * from [dbo].Purses";

            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<PursesDBO> orderDetail = await connection.QueryAsync<PursesDBO>(queryString);

                return orderDetail;
            }
        }

        public async Task<PursesDBO> SelectOnePurse(int ProductId)
        {
            var query = @"Select * From Purses
                         WHERE ProductId = @ProductId";

            using (var connection = new SqlConnection(_connectionString))
            {
                var orderDetail = (await connection.QueryAsync<PursesDBO>(query, new { ProductId })).FirstOrDefault();

                return orderDetail;
            }
        }


        public async Task<bool> UpdateSelectedPurses(PursesDBO model)
        {
            var queryString = @$"UPDATE Purses
                                SET 
                                    PurseName = @PurseName
	                                Brand = @Brand, 
	                                Color =	@Color,
                                    Price = @Price,
                                    Description = @Description
                                WHERE ProductId = @ProductId; ";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(queryString, model);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

       
        
    }
}
