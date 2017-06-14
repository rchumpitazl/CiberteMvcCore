using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;

        public ProductController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Products.GetAll());
        }
    }
}