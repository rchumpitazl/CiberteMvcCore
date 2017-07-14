
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("supplier")]
    public class SupplierController: BaseController
    {
        public SupplierController(IUnitOfWork unit):base(unit)
        {
         
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_unit.Suppliers.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody]Supplier supplier)
        {
            return Ok(_unit.Suppliers.Insert(supplier));
        }
        [HttpPut]
        public IActionResult Update([FromBody]Supplier supplier)
        {
            return Ok(_unit.Suppliers.Update(supplier));
        }
        
    }
}
