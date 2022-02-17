using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using run4cause.Data;
using System;
using System.Linq;

namespace run4cause.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Run4causeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Run4causeContext>>()))
            {
                // Participants
                if (!context.Participant.Any())
                {
                    context.Participant.AddRange(
                        new Participant
                        {
                            LastName = "Bob",
                            FirstName = "Le bricoleur"
                        },

                        new Participant
                        {
                            LastName = "Jack",
                            FirstName = "Le beau"
                        },

                        new Participant
                        {
                            LastName = "Marie",
                            FirstName = "La belle"
                        },

                        new Participant
                        {
                            LastName = "John",
                            FirstName = "Lenon"
                        }
                    );
                }

                // Courses
                if (!context.Course.Any())
                {
                    context.Course.AddRange(
                        new Course
                        {
                            Title = "Course1",
                            Description = "Course1 descritpion"
                        },
                        new Course
                        {
                            Title = "Course2",
                            Description = "Course2 descritpion"
                        },
                        new Course
                        {
                            Title = "Course3",
                            Description = "Course3 descritpion"
                        }
                    );
                }
                
                context.SaveChanges();
            }
        }
    }
}