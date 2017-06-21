using Cibertec.UnitOfWork;
using System.Linq;
using Xunit;
using FluentAssertions;
using Cibertec.Models;

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
        [Fact(DisplayName = "[CustomerRepositoryTests] Get All Customer")]
        public void test1()
        {
            var result = _unit.Customers.GetAll();
            result.Should().NotBeNull();
            result.Count().Should().BeGreaterThan(0);
        }

        
        [Fact(DisplayName = "[CustomerRepositoryTests] Insert Customer")]
        public void test3()
        {
            var result = _unit.Customers.Insert(null);
            result.Should().BeGreaterThan(0);
        }
        [Fact(DisplayName = "[CustomerRepositoryTests] Fail Insert Customer")]
        public void test4()
        {
            var result = _unit.Customers.Insert(new Customer());
            result.Should().Be(0);
        }
    }
}
