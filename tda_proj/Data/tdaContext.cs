using Microsoft.EntityFrameworkCore;
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
            //var basePath = AppDomain.CurrentDomain.BaseDirectory;
            optionsBuilder.UseSqlite(@"Data Source=wwwroot/tdaDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Assuming Lector is your entity
            modelBuilder.Entity<Lector>()
                .Property(l => l.UUID)
                .HasDefaultValueSql("lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-' || '4' || substr(lower(hex(randomblob(2))), 2) || '-' || 'a' || substr(lower(hex(randomblob(2))), 2) || '-' || lower(hex(randomblob(6)))");

            modelBuilder.Entity<Tag>()
                .Property(t => t.TagUUID)
                .HasDefaultValueSql("lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-' || '4' || substr(lower(hex(randomblob(2))), 2) || '-' || 'a' || substr(lower(hex(randomblob(2))), 2) || '-' || lower(hex(randomblob(6)))");

            modelBuilder.Entity<LectorTag>()
                .HasKey(e => new {e.LectorTagUUID, e.LectorUUID});

            modelBuilder.Entity<LectorTag>()
           .HasOne(lt => lt.Lector)
           .WithMany(l => l.lectorTags)
           .HasForeignKey(lt => lt.LectorUUID);

            modelBuilder.Entity<LectorTag>()
                .HasOne(lt => lt.Tag)
                .WithMany(t => t.Tags)
                .HasForeignKey(lt => lt.LectorTagUUID);

        }

    }
}
   
