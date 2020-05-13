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

        public async Task<bool> DeleteSelectedCartItem(int ProductId)
        {
            var query = @"DELETE FROM Cart WHERE ProductId = @ProductId;";


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

        public async Task<IEnumerable<UserDBO>> DisplayAllPurses()
        {
            const string queryString = "Select * from [dbo].Purses";

            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<UserDBO> orderDetail = await connection.QueryAsync<UserDBO>(queryString);

                return orderDetail;
            }
        }

        public async Task<bool> getgrandtotal(int grandtotal)
        {
            var query = @"select * from Customer a
                            join Cart b on b.ID= a.ID
                            Select ((Price * Quantity)*.06) As subtotal from [Cart];";


            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(query, new { grandtotal });
                    return true;
                }
                catch
                {

                    return false;
                }
            }
        }

        public async Task<bool> getsubtotal(int subtotal)
        {
            var query = @"select * from Customer 
                            join Cart  on Cart.ID = Customer.ID;
                            Select (Price * Quantity) As subtotal from [Cart];";


            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(query, new { subtotal });
                    return true;
                }
                catch
                {

                    return false;
                }
            }
        }

        public async Task<bool> InsertCartItem(CartDBO dboCart)
        {
            var queryString = @$"INSERT INTO Cart (PurseName, Brand, Color, Price, Description) 
                                VALUES(@{nameof(CartDBO.ProductID)},@{nameof(CartDBO.PurseName)}, @{nameof(CartDBO.ID)}, @{nameof(CartDBO.Quantity)}, @{nameof(CartDBO.Price)});";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(queryString, dboCart);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> InsertCustomer(CustomerDBO dboCustomer)
        {
            var queryString = @$"INSERT INTO Customer (firstname, lastname, Email, address, city, zipcode, cardnumber, expirationdate, cvv) 
                                VALUES(@{nameof(CustomerDBO.ID)},@{nameof(CustomerDBO.firstname)}, @{nameof(CustomerDBO.lastname)}, @{nameof(CustomerDBO.Email)}, @{nameof(CustomerDBO.address)}, @{nameof(CustomerDBO.city)}, @{nameof(CustomerDBO.zipcode)}, @{nameof(CustomerDBO.cardnumber)}, @{nameof(CustomerDBO.expirationdate)}, @{nameof(CustomerDBO.cvv)} );
                            select * from Customer a
                            join Cart b on b.ID= a.ID
                            Select ((Price * Quantity)*.06) As subtotal from [Cart];
                            select * from Customer a
                            join Cart b on b.ID= a.ID
                            Select ((Price * Quantity)*.06) As subtotal from [Cart];";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var orderDetail = await connection.ExecuteAsync(queryString, dboCustomer);
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

        public async Task<IEnumerable<CartDBO>> SelectAllCartItems()
        {
            const string queryString = "Select * from [dbo].Cart";

            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<CartDBO> orderDetail = await connection.QueryAsync<CartDBO>(queryString);

                return orderDetail;
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

        public async Task<CartDBO> SelectOneCartItem(int ProductId)
        {
            var query = @"Select * From Cart
                         WHERE ProductId = @ProductId";

            using (var connection = new SqlConnection(_connectionString))
            {
                var orderDetail = (await connection.QueryAsync<CartDBO>(query, new { ProductId })).FirstOrDefault();

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
                                    PurseName = @PurseName,
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
                catch(Exception exception)
                {
                    var e = exception;
                    return false;
                }
            }
        }

        public async Task<UserDBO> UserSelectedPurse(int ProductId)
        {
            var query = @"Select * From Purses
                         WHERE ProductId = @ProductId";

            using (var connection = new SqlConnection(_connectionString))
            {
                var orderDetail = (await connection.QueryAsync<UserDBO>(query, new { ProductId })).FirstOrDefault();

                return orderDetail;
            }
        }
    }
}
