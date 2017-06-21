using Cibertec.Models;
using Cibertec.UnitOfWork;
using Moq;
using System.Collections.Generic;

namespace Cibertec.Repositories.Tests
{
    public static class MockedUnitOfWork
    {
        public static IUnitOfWork GetUnitOfWork()
        {
            Mock<IUnitOfWork> unit = new Mock<IUnitOfWork>();
            unit.ConfigureCustomer();
            return unit.Object;
        }
    }

    public static class MockedUnitOfWorkExtensions
    {
        public static Mock<IUnitOfWork> ConfigureCustomer(this Mock<IUnitOfWork> mock)
        {
            mock.Setup(c => c.Customers.GetAll()).Returns(
                new List<Customer>
                {
                    new Customer
                    {
                        Id= 1,
                        City = "Lima",
                        Country = "Perú",
                        FirstName = "Edinson",
                        LastName = "Chumpitaz",
                        Phone = "555-5555",
                        Orders = new List<Order>()
                    },
                    new Customer
                    {
                        Id= 2,
                        City = "Lima",
                        Country = "Perú",
                        FirstName = "Raul",
                        LastName = "Huaman",
                        Phone = "666-6666",
                        Orders = new List<Order>()
                    }
                });
            
            mock.Setup(c => c.Customers.GetEntityById(1)).
               Returns(
               new Customer
               {
                   Id = 1,
                   City = "Lima",
                   Country = "Perú",
                   FirstName = "Edinson",
                   LastName = "Chumpitaz",
                   Phone = "555-5555",
                   Orders = new List<Order>()
               });
            /*
            mock.Setup(c => c.Customers.SearchByNames("Edinson", "Chumpitaz")).Returns(
                new Customer
                {
                    Id = 1,
                    City = "Lima",
                    Country = "Perú",
                    FirstName = "Edinson",
                    LastName = "Chumpitaz",
                    Phone = "555-5555",
                    Orders = new List<Order>()
                }
            );*/
            mock.Setup(c => c.Customers.Insert(null)).Returns(1);
            return mock;
        }
    }
}
