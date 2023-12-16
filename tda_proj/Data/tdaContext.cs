﻿using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using tda_proj.Model;

namespace tda_proj.Data
{
    public class tdaContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<LectorTag> LectorTags { get; set; }
        public DbSet<ContactEmail> Emails { get; set; }
        public DbSet<ContactTelNumber> TelNumbers { get; set; }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<TitleAfter> TitlesAfter { get; set; }
        public DbSet<TitleBefore> TitlesBefore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M1F59UB\SQLEXPRESS;Database=TdA;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Assuming Lector is your entity
            modelBuilder.Entity<Lector>()
                .Property(l => l.UUID)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Tag>()
                .Property(t => t.TagUUID)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<LectorTag>()
                .HasKey(e => new {e.LectorTagUUID, e.LectorUUID});
        }

    }
}
   