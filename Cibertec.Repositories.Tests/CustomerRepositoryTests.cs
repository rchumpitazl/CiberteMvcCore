using Cibertec.UnitOfWork;
using System.Linq;
using Xunit;
using FluentAssertions;
using Cibertec.Models;
using Cibertec.MockData;

namespace Cibertec.Repositories.Tests
{
    public class CustomerRepositoryTests
    {
        private readonly IUnitOfWork _unit;

        public CustomerRepositoryTests()
        {
            //_unit = new CibertecUnitOfWork(ConfigSettings.ConnectionString);
            _unit = MockedUnitOfWork.GetUnitOfWork();
        }
        [Fact(DisplayName = "First Unit Test")]
        public void First_Unit_Test()
        {
            var customer = _unit.Customers.GetEntityById(1);
            customer.Should().NotBeNull();
        }

        [Fact(DisplayName = "Get All Test")]
        public void Customer_Get_All()
        {
            var customerList = _unit.Customers.GetAll().ToList();
            customerList.Should().NotBeNull();
            customerList.Count.Should().BeGreaterThan(0);
            customerList.Count.Should().Be(2);
        }

        
        [Fact(DisplayName = "Customer Insert Test")]
        public void Customer_Insert()
        {
            var result = _unit.Customers.Insert(new Customer());
            result.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "Customer Update Test")]
        public void Customer_Update()
        {
            var result = _unit.Customers.Update(new Customer());
            result.Should().BeTrue();
        }
        [Fact(DisplayName = "Customer Delete Test")]
        public void Customer_Delete()
        {
            var result = _unit.Customers.Delete(new Customer());
            result.Should().BeTrue();
        }
        [Theory(DisplayName = "Customer Search by Test")]
        [InlineData("Edinson", "Chumpitaz")]
        [InlineData("Raul", "Huaman")]
        [InlineData("Alan", "Garcia")]
        public void Customer_SearchByName(string firstName,string lastName)
        {
            var result = _unit.Customers.SearchByNames(firstName, lastName);
            result.Should().NotBeNull();
        }
    }
}
