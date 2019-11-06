using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NanoSurveyAPI.Models;
using NanoSurveyAPI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Controllers
{
    [Route("api/surveys")]
    public class InterviewsController : Controller
    {
        private NanoSurveyContext _ctx;

        public InterviewsController(NanoSurveyContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("{surveyId}")]
        public IActionResult PostInterview(int surveyId, [FromBody] InterviewForCreationDto interview)
        {
            if (interview == null)
            {
                return BadRequest();
            }
                
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = _ctx.Surveys.FirstOrDefault(s => s.Id == surveyId);

            if (survey == null)
            {
                NotFound();
            }

            survey.Interviews.Add(new Interview { FirstName = interview.FirstName, LastName = interview.LastName });
            _ctx.SaveChanges();

            return NoContent();
        }

        [HttpPut("{surveyId}/interviews/{interviewId}/questions/{questionId}")]
        public IActionResult SavetResult(int surveyId, int interviewId, int questionId, [FromBody] int answerId)
        {
            var currentInterview = _ctx.Interviews.Include(i => i.Results).FirstOrDefault(i => i.Id == interviewId);

            var currentQuestion = _ctx.Questions.Include(q => q.Survey).Include(q => q.Answers).FirstOrDefault(q => q.Id == questionId);

            var pickedAnswer = _ctx.Answers.Include(a => a.Question).FirstOrDefault(a => a.Id == answerId);

            // if the question in that interview has already been answered then update it
            if (currentInterview.Results.Select(r => r.Answer).Intersect(currentQuestion.Answers).Any())
            {
                var intersection = currentInterview.Results
                    .Select(r => r.Answer)
                    .Intersect(currentQuestion.Answers)
                    .First();
                var resultToUpdate = currentInterview.Results
                    .FirstOrDefault(r => r.Answer == intersection);
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

            // if currentQuestion is last in the survey then return 204 
            if (nextQuestionNumber > _ctx.Surveys.FirstOrDefault(s => s.Id == surveyId).Questions.Count())
            {
                return NoContent();
            }

            return Ok(_ctx.Questions.FirstOrDefault(q => q.Number == nextQuestionNumber).Id);
        }
    }
}
