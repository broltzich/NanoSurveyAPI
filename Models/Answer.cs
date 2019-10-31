using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public Question Question { get; set; }

        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
