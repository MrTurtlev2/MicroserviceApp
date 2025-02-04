
using MicroserviceRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceRestApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Pupils> Pupils { get; set; }
        public DbSet<Exercises> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji jeden do wielu 
            modelBuilder.Entity<Trainers>()
                .HasMany(t => t.PupilsList);

            modelBuilder.Entity<Pupils>()
              .HasMany(t => t.ExercisesList);
            modelBuilder.Entity<Pupils>()
                          .HasMany(p => p.ExercisesList)
                          .WithOne(e => e.Pupil)
                          .HasForeignKey(e => e.PupilId); 

            modelBuilder.Entity<Trainers>().HasData(
                new Trainers { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123" },
                new Trainers { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password456" }
            );

            modelBuilder.Entity<Pupils>().HasData(
                new Pupils { Id = 1, Name = "Mike Johnson", Email = "mike.johnson@example.com", Password = "password789", TrainerId = 1 },
                new Pupils { Id = 2, Name = "Emily Davis", Email = "emily.davis@example.com", Password = "password101", TrainerId = 2 }
            );

            modelBuilder.Entity<Exercises>().HasData(
                new Exercises { Id = 1, Label = "Wyciskanie sztangi", Reps = 5, Weight = "50", Comment = "brak", PupilId = 1 },
                new Exercises { Id = 2, Label = "Przysiady ze sztanga", Reps = 12, Weight = "90", Comment = "brak", PupilId = 2 }
            );

        }

    }
}