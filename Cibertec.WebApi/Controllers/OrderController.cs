using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("order")]
    public class OrderController: BaseController
    {
        public OrderController(IUnitOfWork unit):base(unit)
        {
         
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_unit.Orders.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody]Order order)
        {
            return Ok(_unit.Orders.Insert(order));
        }
        [HttpPut]
        public IActionResult Update([FromBody]Order order)
        {
            return Ok(_unit.Orders.Update(order));
        }
        
    }
}
