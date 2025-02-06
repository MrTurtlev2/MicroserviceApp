
using MicroservicePdfGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePdfGenerator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Pupils> Pupils { get; set; }
        public DbSet<Exercises> Exercises { get; set; }

    }
}