using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NorthwindDbContext _context;

        public CustomerController(NorthwindDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Customers);
        }
    }
}