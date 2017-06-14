using Cibertec.Models;
using Cibertec.Repositories;
using Cibertec.Repositories.Northwind;
using Cibertec.Repositories.Northwind.EF;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork(DbContext _context)
        {
            Customers = new CustomerRepository(_context);
            Orders = new RepositoryEF<Order>(_context);
            OrderItems = new RepositoryEF<OrderItem>(_context);
            Products = new RepositoryEF<Product>(_context);
            Suppliers = new RepositoryEF<Supplier>(_context);

        }
        public ICustomerRepository Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
    }
}
