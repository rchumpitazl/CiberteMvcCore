using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("product")]
    public class ProductController: BaseController
    {
        public ProductController(IUnitOfWork unit):base(unit)
        {
         
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_unit.Products.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody]Product product)
        {
            return Ok(_unit.Products.Insert(product));
        }
        [HttpPut]
        public IActionResult Update([FromBody]Product product)
        {
            return Ok(_unit.Products.Update(product));
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.Products.GetEntityById(id));
        }
        [HttpDelete]
        public IActionResult Delete([FromBody]Product product)
        {
            return Ok(_unit.Products.Delete(product));
        }

    }
}
