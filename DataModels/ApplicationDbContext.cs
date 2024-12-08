using DataModels.Models;
using Microsoft.EntityFrameworkCore;
namespace DataModels
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { } 
         
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Pupils> Pupils { get; set; }
        public DbSet<Exercises> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji jeden do wielu
            modelBuilder.Entity<Trainers>()
                .HasMany(t => t.PupilsList)
                .WithOne(p => p.Trainer)
                .HasForeignKey(p => p.TrainerId);
        }
    }
}
