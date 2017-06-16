using Cibertec.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {

        public OrderItemRepository(string connectionString):base(connectionString)
        {

        }

        public OrderItem MaxOrEqualUnitPrice(decimal unitprice)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@unitprice", unitprice);
                return connection.QueryFirst<OrderItem>("dbo.MaxOrEqualUnitPrice",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
