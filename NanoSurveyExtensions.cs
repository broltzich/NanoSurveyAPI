using NanoSurveyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurveyAPI
{
    public static class NanoSurveyExtensions
    {
        public static void EnsureSeedDataForContext(this NanoSurveyContext context)
        {
            if (context.Surveys.Any())
            {
                return;
            }

            // init seed data
            var surveys = new List<Survey>()
            {
                new Survey()
                {
                    Description = "A simple survey about work.",
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Text = "Where the company you work for is located?"
                        },
                        new Question()
                        {
                            Text = "How long does it take you to get to the place of work?"
                        },
                        new Question()
                        {
                            Text = "Which kind of transport do you use?"
                        }
                    }
                }
            };

            context.Surveys.AddRange(surveys);
            context.SaveChanges();
        }
    }
}
