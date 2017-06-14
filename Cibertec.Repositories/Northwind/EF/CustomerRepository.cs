using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.Northwind.EF
{
    public class CustomerRepository : RepositoryEF<Customer>, ICustomerRepository
    {

        public CustomerRepository(DbContext context) :base(context)
        {

        }

        public Customer SearchByNames(string firstName, string lastName)
        {
            return _context.Set<Customer>().FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }
    }
}
