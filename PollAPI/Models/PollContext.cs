using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class PollContext : DbContext
    {
        public PollContext(DbContextOptions<PollContext> options) : base(options) { }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Antwoord> Antwoorden { get; set; }
        public DbSet<Stem> Stemmen { get; set; }
        public DbSet<PollGebruiker> PollGebruikers { get; set; }
        public DbSet<Vriend> Vrienden { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //database tabellen aanmaken
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<Poll>().ToTable("Poll");
            modelBuilder.Entity<Antwoord>().ToTable("Antwoord");
            modelBuilder.Entity<Stem>().ToTable("Stemmen");
            modelBuilder.Entity<PollGebruiker>().ToTable("PollGebruiker");
            modelBuilder.Entity<Vriend>()
                .HasOne(v => v.Verzender)
                .WithMany(g => g.VerzondenVerzoeken)
                .IsRequired()
                .HasForeignKey(v => v.VerzenderID)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Vriend>()
                .HasOne(v => v.Ontvanger)
                .WithMany(g => g.OntvangenVerzoeken)
                .IsRequired()
                .HasForeignKey(v => v.OntvangerID)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Vriend>().ToTable("Vriend");
        }
    }
}
