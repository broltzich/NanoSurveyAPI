using Microsoft.AspNetCore.Mvc;
using NanoSurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    public class InterviewsController : Controller
    {
        private NanoSurveyContext _ctx;

        public InterviewsController(NanoSurveyContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPut("{interviewId}")]
        public IActionResult PutResult(int interviewId, [FromBody] int answerId)
        {
            var currentInterview = _ctx.Interviews.FirstOrDefault(i => i.Id == interviewId);

            var pickedAnswer = _ctx.Answers.FirstOrDefault(a => a.Id == answerId);

            var currentQuestion = pickedAnswer.Question;

            // if the question in that interview has already been answered then update it
            if (currentInterview.Results.Select(r => r.Answer).Intersect(currentQuestion.Answers).Any())
            {
                var resultToUpdate = currentInterview.Results
                    .FirstOrDefault(r => r.Answer.Question == currentQuestion);
                resultToUpdate.Answer = pickedAnswer;
            }
            else
            {
                var newResult = new Result
                {
                    Answer = pickedAnswer
                };
                currentInterview.Results.Add(newResult);
            }

            _ctx.SaveChanges();

            var nextQuestionNumber = (int)currentQuestion.Number;
            nextQuestionNumber++;

            return Ok(currentInterview.Survey.Questions.FirstOrDefault(q => q.Number == nextQuestionNumber).Id);
        }
    }
}
