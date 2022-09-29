using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArrangmeneterOslov2.Models;

    public class ArrangementContext : DbContext
    {
        public ArrangementContext (DbContextOptions<ArrangementContext> options)
            : base(options)
        {
        }

        public DbSet<ArrangmeneterOslov2.Models.Arrangement> Arrangement { get; set; } = default!;

        public DbSet<ArrangmeneterOslov2.Models.ArrangementType> ArrangementType { get; set; }

        public DbSet<ArrangmeneterOslov2.Models.ArrangementVenue> ArrangementVenue { get; set; }
    }
