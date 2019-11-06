using Microsoft.AspNetCore.Mvc;
using NanoSurveyAPI.Models;
using NanoSurveyAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly NanoSurveyContext _ctx;

        public QuestionsController(NanoSurveyContext ctx)
        {
            _ctx = ctx;  
        }

        [HttpGet("{questionId}")]
        public IActionResult GetAnswers(int questionId)
        {
            var question = _ctx.Questions.FirstOrDefault(q => q.Id == questionId);

            var answers = _ctx.Answers.Where(a => a.Question.Id == questionId);


            if (question == null)
            {
                return NotFound();
            }

            var questionToReturn = new QuestionDto
            {
                Id = question.Id,
                Number = question.Number,
                Text = question.Text,
                Answers = answers.Select(a => new AnswerDto { Id = a.Id, Text = a.Text }).ToList()
            };
            return Ok(questionToReturn);
        }
    }
}
