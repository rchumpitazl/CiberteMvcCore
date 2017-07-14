using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("orderitem")]
    public class OrderItemController: BaseController
    {
        public OrderItemController(IUnitOfWork unit):base(unit)
        {
         
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_unit.OrderItems.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody]OrderItem orderItem)
        {
            return Ok(_unit.OrderItems.Insert(orderItem));
        }
        [HttpPut]
        public IActionResult Update([FromBody]OrderItem orderItem)
        {
            return Ok(_unit.OrderItems.Update(orderItem));
        }
        
    }
}
