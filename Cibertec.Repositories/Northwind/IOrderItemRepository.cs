﻿using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        OrderItem MaxOrEqualUnitPrice(decimal unitprice);
    }
}
