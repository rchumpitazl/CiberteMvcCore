using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IUserRepository
    {
        User ValidaterUser(string email, string password);
    }
}
