using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VirtualStudioBl.Model
{
    public class VirtualManagerContext : DbContext
    {
        public VirtualManagerContext() : base("VirtualManagerConnection")
        { }
            public DbSet<Computer> Computers { get; set; }

            public DbSet<MainComputer> MainComputers { get; set; }

            public DbSet<Notification> Notifications { get; set; }

            public DbSet<Screens> Screens { get; set; }

            public DbSet<Streem> Streems { get; set; }

            public DbSet<Coworker> Coworkers { get; set; }
        
    }
}
