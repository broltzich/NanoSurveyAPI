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
                var answers1 = new List<Answer>
                {
                    new Answer
                    {
                        Text = "Moscow"
                    },
                    new Answer
                    {
                        Text = "Moscow region"
                    },
                    new Answer
                    {
                        Text = "St. Petersburg"
                    },
                    new Answer
                    {
                        Text = "Other"
                    }
                };
                var answers2 = new List<Answer>
                {
                    new Answer
                    {
                        Text = "Less than 30 minutes."
                    },
                    new Answer
                    {
                        Text = "From 30 to 60 minutes."
                    },
                    new Answer
                    {
                        Text = "From 1 to 2 hours."
                    },
                    new Answer
                    {
                        Text = "More than 2 hours."
                    }
                };
                var answers3 = new List<Answer>
                {
                    new Answer
                    {
                        Text = "Buses, trams, etc."
                    },
                    new Answer
                    {
                        Text = "Underground"
                    },
                    new Answer
                    {
                        Text = "Taxi"
                    },
                    new Answer
                    {
                        Text = "Personal car"
                    }
                };
                var surveys = new List<Survey>
                {
                    new Survey
                    {
                        Description = "A simple work interview.",
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Number = 1,
                                Text = "Where your place of work is located?",
                                Answers = answers1
                            },
                            new Question
                            {
                                Number = 2,
                                Text = "How long does it take you to get to your place of work?",
                                Answers = answers2
                            },
                            new Question
                            {
                                Number = 3,
                                Text = "Which mean of transport do you usually use?",
                                Answers = answers3
                            }
                        }
                    }
                };

                var someSurvey = surveys.First();
                var rnd = new Random();
                var interviews = new List<Interview>
                {
                    new Interview
                    {
                        FirstName = "Bob",
                        LastName = "Dou",
                        Date = DateTime.Now,
                        Survey = someSurvey,
                        Results = new List<Result>
                        {
                            new Result
                            {
                                Answer = answers1[rnd.Next(answers1.Count - 1)]
                            },
                            new Result
                            {
                                Answer = answers2[rnd.Next(answers2.Count - 1)]
                            },
                            new Result
                            {
                                Answer = answers3[rnd.Next(answers3.Count - 1)]
                            }
                        }
                    },
                    new Interview
                    {
                        FirstName = "John",
                        LastName = "Barrel",
                        Date = DateTime.Now.AddHours(-3),
                        Survey = someSurvey,
                        Results = new List<Result>
                        {
                            new Result
                            {
                                Answer = answers1[rnd.Next(answers1.Count - 1)]
                            },
                            new Result
                            {
                                Answer = answers2[rnd.Next(answers2.Count - 1)]
                            },
                            new Result
                            {
                                Answer = answers3[rnd.Next(answers3.Count - 1)]
                            }
                        }
                    },
                    new Interview
                    {
                        FirstName = "Ann",
                        LastName = "Hepo",
                        Date = DateTime.Now.AddHours(-2),
                        Survey = someSurvey,
                        Results = new List<Result>
                        {
                            new Result
                            {
                                Answer = answers1[rnd.Next(answers1.Count - 1)]
                            },
                            new Result
                            {
                                Answer = answers2[rnd.Next(answers2.Count - 1)]
                            },
                            new Result
                            {
                                Answer = answers3[rnd.Next(answers3.Count - 1)]
                            }
                        }
                    },
                };

                context.Surveys.AddRange(surveys);
                context.Interviews.AddRange(interviews);
                context.SaveChanges();
            }
        }
    }
}
