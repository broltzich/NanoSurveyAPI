using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Models
{
    public class Result
    {
        public int Id { get; set; }

        public Interview Interview { get; set; }

        public Answer Answer { get; set; }
    }
}
