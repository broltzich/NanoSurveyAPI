using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI.Models
{
    public class NanoSurveyContext : DbContext
    {
        public NanoSurveyContext(DbContextOptions<NanoSurveyContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
