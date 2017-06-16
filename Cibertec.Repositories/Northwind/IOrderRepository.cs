﻿using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderRepository:IRepository<Order>
    {
        Order ByOrderNumber(string ordernumber);
    }
}
