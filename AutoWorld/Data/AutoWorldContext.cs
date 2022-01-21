#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoWorld.Models;

namespace AutoWorld.Data
{
    public class AutoWorldContext : DbContext
    {
        public AutoWorldContext (DbContextOptions<AutoWorldContext> options)
            : base(options)
        {
        }

        public DbSet<AutoWorld.Models.Car> Car { get; set; }

        public DbSet<AutoWorld.Models.DealerAuto> DealerAuto { get; set; }

        public DbSet<AutoWorld.Models.Category> Category { get; set; }
    }
}
