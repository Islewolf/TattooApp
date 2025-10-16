using Microsoft.EntityFrameworkCore;

namespace TattooApp.Models {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Specialty> Specialties => Set<Specialty>();
        //public DbSet<Binder> Binders => Set<Binder>();
        //public DbSet<FlashCard> FlashCards => Set<FlashCard>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Artist and Specialty
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Specialties)
                .WithMany(s => s.Artists);
        }
    }
}
