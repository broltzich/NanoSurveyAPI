using NanoSurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.ViewModels
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Text { get; set; }

        public ICollection<AnswerDto> Answers { get; set; }
    }
}
