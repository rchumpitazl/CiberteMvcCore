﻿using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository:IRepository<Product>
    {
        Product ByProductName(string productname);
    }
}
