using Microsoft.AspNetCore.Mvc;
using NanoSurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Controllers
{
    public class DummyController : Controller
    {
        private NanoSurveyContext _ctx;

        public DummyController(NanoSurveyContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

        //[HttpGet]
        //[Route("api/question/{}")]
    }
}
