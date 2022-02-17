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

                // Runs
                if (!context.Run.Any())
                {
                    context.Run.AddRange(
                        new Run
                        {
                            Title = "Run1",
                            Description = "Run1 descritpion"
                        },
                        new Run
                        {
                            Title = "Run2",
                            Description = "Run2 descritpion"
                        },
                        new Run
                        {
                            Title = "Run3",
                            Description = "Run3 descritpion"
                        }
                    );
                }
                
                context.SaveChanges();
            }
        }
    }
}