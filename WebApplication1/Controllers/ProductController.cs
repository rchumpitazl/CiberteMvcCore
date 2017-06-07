using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindDbContext _context;

        public ProductController(NorthwindDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products);
        }
    }
}