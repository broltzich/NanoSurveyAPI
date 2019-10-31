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
            if (!context.Surveys.Any())
            {
                var surveys = new List<Survey>()
                {
                    new Survey()
                    {
                        Description = "A simple work interview.",
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Number = 1,
                                Text = "Where your place of work is located?",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Text = "Moscow"
                                    },
                                    new Answer()
                                    {
                                        Text = "Moscow region"
                                    },
                                    new Answer()
                                    {
                                        Text = "St. Petersburg"
                                    },
                                    new Answer()
                                    {
                                        Text = "Other"
                                    }
                                }
                            },
                            new Question()
                            {
                                Number = 2,
                                Text = "How long does it take you to get to your place of work?",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Text = "Less than 30 minutes."
                                    },
                                    new Answer()
                                    {
                                        Text = "From 30 to 60 minutes."
                                    },
                                    new Answer()
                                    {
                                        Text = "From 1 to 2 hours."
                                    },
                                    new Answer()
                                    {
                                        Text = "More than 2 hours."
                                    }
                                }
                            },
                            new Question()
                            {
                                Number = 3,
                                Text = "Which mean of transport do you usually use?",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Text = "Buses, trams, etc."
                                    },
                                    new Answer()
                                    {
                                        Text = "Underground"
                                    },
                                    new Answer()
                                    {
                                        Text = "Taxi"
                                    },
                                    new Answer()
                                    {
                                        Text = "Personal car"
                                    }
                                }
                            }
                        }
                    }
                };

                context.Surveys.AddRange(surveys);
                context.SaveChanges();
            }

            

            return;
            // init seed data
            
        }
    }
}
