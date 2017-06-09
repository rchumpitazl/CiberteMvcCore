using Cibertec.UnitOfWork;
using Cibertec.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IUnitOfWork _unit;

        public OrderItemController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.OrderItems.GetAll());
        }
    }
}