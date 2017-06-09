using Cibertec.UnitOfWork;
using Cibertec.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unit;

        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Orders.GetAll());
        }
    }
}