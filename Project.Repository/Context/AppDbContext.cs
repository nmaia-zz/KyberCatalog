using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Domain.Entities;
using Project.Repository.Mappings.EntityFramework;
using System.IO;

namespace Project.Repository.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KyberMap());

            modelBuilder.Entity<Kyber>()
                .HasIndex(i => i.Name).IsUnique();
        }
        public DbSet<Kyber> Kybers { get; set; }
    }
}
