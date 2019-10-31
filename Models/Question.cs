using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public Survey Survey { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        //public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
