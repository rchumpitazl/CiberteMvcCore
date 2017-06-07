using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class SupplierController : Controller
    {
        private readonly NorthwindDbContext _context;

        public SupplierController(NorthwindDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Suppliers);
        }
    }
}