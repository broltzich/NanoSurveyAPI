using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Models
{
    public class Survey
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
