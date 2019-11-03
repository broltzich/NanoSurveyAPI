using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NanoSurveyAPI.Models;
using NanoSurveyAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    public class SurveysController : Controller
    {
        private NanoSurveyContext _ctx;

        public SurveysController(NanoSurveyContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet()]
        public IActionResult GetSurveys()
        {
            var surveysToReturn = _ctx.Surveys.Select(s => new SurveyDto { Id = s.Id, Description = s.Description }).ToList();

            if (surveysToReturn == null)
            {
                return NotFound();
            }

            return Ok(surveysToReturn);
        }

        [HttpGet("{surveyId}/questions/{questionId}")]
        public IActionResult GetQuestion(int surveyId, int questionId)
        {
            var question = _ctx.Questions.FirstOrDefault(q => q.Id == questionId);

            var questionToReturn = new QuestionDto
            {
                Id = question.Id,
                Number = question.Number,
                Text = question.Text,
                Answers = question.Answers.Select(q => new AnswerDto { Id = q.Id, Text = q.Text }).ToList()
            };

            if (questionToReturn == null)
            {
                return NotFound();
            }

            return Ok(questionToReturn);
        }

    }
}
