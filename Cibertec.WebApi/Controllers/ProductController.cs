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
        
    }
}
