using System;
using System.Collections.Generic;
using System.Text;
using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork(DbContext _context)
        {
            Customers = new ReposityEF<Customer>(_context);
            Orders = new ReposityEF<Order>(_context);
            OrderItems = new ReposityEF<OrderItem>(_context);
            Products = new ReposityEF<Product>(_context);
            Suppliers = new ReposityEF<Supplier>(_context);

        }
        public IRepository<Customer> Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
    }
}
