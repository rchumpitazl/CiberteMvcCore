using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository:IRepository<Product>
    {
        Product ByProductName(string productname);
        IEnumerable<Product> ListProductPage(int startrow, int endrow);
        int RowNumbers();
    }
}
