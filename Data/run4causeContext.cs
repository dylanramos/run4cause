#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using run4cause.Models;

namespace run4cause.Data
{
    public class run4causeContext : DbContext
    {
        public run4causeContext (DbContextOptions<run4causeContext> options)
            : base(options)
        {
        }

        public DbSet<run4cause.Models.Participant> Participant { get; set; }
    }
}
