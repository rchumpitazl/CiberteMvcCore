﻿using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }

      
    }
}
