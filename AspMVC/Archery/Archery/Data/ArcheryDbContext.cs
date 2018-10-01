using Archery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Archery.Data
{
    public class ArcheryDbContext : DbContext
    {
        public ArcheryDbContext() : base("Archery")
        {
        }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Archer> Archers { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Shooter> Shooters { get; set; }
    }
}