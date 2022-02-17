#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using run4cause.Models;

namespace run4cause.Data
{
    public class Run4causeContext : DbContext
    {
        public Run4causeContext (DbContextOptions<Run4causeContext> options)
            : base(options)
        {
        }

        public DbSet<run4cause.Models.Participant> Participant { get; set; }

        public DbSet<run4cause.Models.Run> Run { get; set; }
    }
}
