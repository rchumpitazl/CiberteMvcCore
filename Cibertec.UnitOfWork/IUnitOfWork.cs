using Cibertec.Models;
using Cibertec.Repositories;
using Cibertec.Repositories.Northwind;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IProductRepository Products { get; }
        IRepository<Supplier> Suppliers { get; }
    }
}
