using Cibertec.MockData;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Controllers;
using Xunit;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using Cibertec.Models;

namespace Cibertec.Web.Tests
{
    public class CustomerControllerTests
    {
        private readonly IUnitOfWork _unit;

        public CustomerControllerTests()
        {
            //_unit = new CibertecUnitOfWork(ConfigSettings.ConnectionString);
            _unit = MockedUnitOfWork.GetUnitOfWork();
        }


        [Fact(DisplayName = "Index Test")]
        public void Index_Test()
        {
            var controller = new CustomerController(_unit);
            var result = controller.Index() as ViewResult;
            result.Should().NotBeNull();
            var customers = (List<Customer>)result.Model;
            customers.Should().NotBeNull();
            customers.Count.Should().BeGreaterThan(0);
            customers.Count.Should().Be(2);
        }
        [Fact(DisplayName = "Detail Not Found Test")]
        public void Detail_Test()
        {
            var controller = new CustomerController(_unit);
            var result = controller.Detail() as ViewResult;
            result.Should().NotBeNull();
            var customer = (Customer)result.Model;
            customer.Should().BeNull();
        }
    }
}
