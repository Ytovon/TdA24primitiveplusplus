using Microsoft.EntityFrameworkCore;
using tda_proj.Moodels;

namespace tda_proj.Data
{
    public class tda_proj_Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<LectorTag> lectorTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8Q71K8S;Database=TdA;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}
   
