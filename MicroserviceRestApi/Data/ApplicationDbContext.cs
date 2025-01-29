
using MicroserviceRestApi.Models;
using Microsoft.EntityFrameworkCore;
namespace MicroserviceRestApi
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

            modelBuilder.Entity<Trainers>().HasData(
             new Trainers { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123" },
             new Trainers { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password456" }
            );

            modelBuilder.Entity<Pupils>().HasData(
              new Pupils { Id = 1, Name = "Mike Johnson", Email = "mike.johnson@example.com", Password = "password789", TrainerId = 1 },
              new Pupils { Id = 2, Name = "Emily Davis", Email = "emily.davis@example.com", Password = "password101", TrainerId = 2 }
          );
        }
    }
}
