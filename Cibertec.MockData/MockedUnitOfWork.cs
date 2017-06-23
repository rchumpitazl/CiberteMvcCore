using Cibertec.Models;
using Cibertec.UnitOfWork;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Cibertec.MockData
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
            var customerList = new List<Customer>
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
                };
            mock.Setup(c => c.Customers.GetEntityById(It.IsAny<int>())).
               Returns(
                (int id) => {
                    return customerList.FirstOrDefault(x => x.Id == id);
                }
               );
            mock.Setup(c => c.Customers.GetAll()).Returns(customerList);
            mock.Setup(c => c.Customers.Insert(It.IsAny<Customer>())).Returns(1);
            mock.Setup(c => c.Customers.Update(It.IsAny<Customer>())).Returns(true);
            mock.Setup(c => c.Customers.Delete(It.IsAny<Customer>())).Returns(true);
            mock.Setup(c => c.Customers.SearchByNames(It.IsAny<string>(), It.IsAny<string>())).
                Returns(
                    (string firstName, string lastName) =>
                    {
                        return customerList.FirstOrDefault(x => x.FirstName == firstName &&
                        x.LastName == lastName);
                    }
                );


            return mock;
        }
    }
}
