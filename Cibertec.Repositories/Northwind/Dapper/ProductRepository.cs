using Cibertec.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {

        public ProductRepository(string connectionString):base(connectionString)
        {

        }

        public Product ByProductName(string productname)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@productname", productname);
                return connection.QueryFirst<Product>("dbo.ByProductName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
