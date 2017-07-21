using Cibertec.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {

        public ProductRepository(string connectionString):base(connectionString)
        {

        }

        public int RowNumbers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               
                return connection.ExecuteScalar<int>("SELECT Count(Id) FROM dbo.Product");
            }
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

        public IEnumerable<Product> ListProductPage(int startrow, int endrow)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startrow);
                parameters.Add("@endrow", endrow);

                return connection.Query<Product>("dbo.ProductPagedList",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
