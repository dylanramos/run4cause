﻿using Microsoft.EntityFrameworkCore;
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
                if (context.Participant.Any())
                {
                    return;
                }

                var participants = new Participant[]
                {
                    new Participant { FirstName = "Bob", LastName = "Le bricoleur"},
                    new Participant { FirstName = "Jack", LastName = "Le beau"},
                    new Participant { FirstName = "Marie", LastName = "La belle"},
                    new Participant { FirstName = "John", LastName = "Lenon"}
                };

                foreach (Participant participant in participants)
                {
                    context.Participant.Add(participant);
                }
                context.SaveChanges();

                // Runs
                if (context.Run.Any())
                {
                    return;
                }

                var runs = new Run[]
                {
                    new Run { Title = "Run1", Description = "Run1 descritpion" },
                    new Run { Title = "Run2", Description = "Run2 descritpion" },
                    new Run { Title = "Run3", Description = "Run3 descritpion" }
                };

                foreach (Run run in runs)
                {
                    context.Run.Add(run);
                }
                context.SaveChanges();

                // Participations
                var participations = new Participation[]
                {
                    new Participation 
                    { 
                        ParticipantID = participants.Single(p => p.FirstName == "Bob").Id,
                        RunID = runs.Single(r => r.Title == "Run1").Id,
                        DateTime = DateTime.Now
                    },
                    new Participation
                    {
                        ParticipantID = participants.Single(p => p.FirstName == "Jack").Id,
                        RunID = runs.Single(r => r.Title == "Run2").Id,
                        DateTime = DateTime.Now
                    },
                };

                foreach (Participation participation in participations)
                {
                    context.Participation.Add(participation);
                }
                context.SaveChanges();
            }
        }
    }
}