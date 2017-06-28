﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cibertec.Automation.Tests
{
    public class CustomerPageTests
    {
        private readonly CustomerPage _customerPage;

        public CustomerPageTests()
        {
            Driver.GetInstance();
            _customerPage = new CustomerPage();
        }

        [Fact]
        public void Customer_List_Automation()
        {
            _customerPage.GoToUrl();
            _customerPage.GoToIndex();
            _customerPage.GetListCount().Should().BeGreaterThan(90);
            Driver.CloseInstance();
        }
    }
}
