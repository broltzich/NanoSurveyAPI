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
            var questions = _ctx.Questions;
            var answers = _ctx.Answers;
            var interviews = _ctx.Interviews;
            var results = _ctx.Results;
            return Ok();
        }

        //[HttpGet]
        //[Route("api/question/{}")]
    }
}
