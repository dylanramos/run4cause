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
                // Look for any Participants.
                if (context.Participant.Any())
                {
                    return;   // DB has been seeded
                }

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
                context.SaveChanges();
            }
        }
    }
}