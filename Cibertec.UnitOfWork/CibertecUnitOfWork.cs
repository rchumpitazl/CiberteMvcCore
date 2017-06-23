using Cibertec.Models;
using Cibertec.Repositories;
using Cibertec.Repositories.Northwind.Dapper;
using Cibertec.Repositories.Northwind;

namespace Cibertec.UnitOfWork
{
    public class CibertecUnitOfWork:IUnitOfWork
    {
        public CibertecUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
            Orders = new Repository<Order>(connectionString);
            OrderItems = new Repository<OrderItem>(connectionString);
            Products = new ProductRepository(connectionString);
            Suppliers = new Repository<Supplier>(connectionString);

        }
        public ICustomerRepository Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IProductRepository Products { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
    }
}
