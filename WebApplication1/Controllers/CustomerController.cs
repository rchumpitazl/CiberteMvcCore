using Cibertec.UnitOfWork;
using Cibertec.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ExceptionLoggerFilter]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Customers.GetAll());
        }

        


        public  IActionResult Detail(){

            return View(_unit.Customers.SearchByNames("Maria", "Anders"));
        }
    }
}