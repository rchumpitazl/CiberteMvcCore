using Cibertec.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public OrderRepository(string connectionString):base(connectionString)
        {

        }

        public Order ByOrderNumber(string ordernumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ordernumber", ordernumber);
                return connection.QueryFirst<Order>("dbo.ByOrderNumber",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
