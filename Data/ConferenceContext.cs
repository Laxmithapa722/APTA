using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APTA.Models;

namespace APTA.Data
{
    public class ConferenceContext : DbContext
    {
        public ConferenceContext (DbContextOptions<ConferenceContext> options)
            : base(options)
        {
        }
        public DbSet<Member> Member { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Conference> Conference { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Speaker> Speaker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>().ToTable("Conference");
            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Organiser>().ToTable("Organiser");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
        }

    }
}
