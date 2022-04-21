using Microsoft.EntityFrameworkCore;
using SmartPoles.Domain.Entities;
using System;

namespace SmartPoles.Data
{
    public class SmartPolesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Pole> Poles { get; set; }
        public DbSet<PoleMetric> PoleMetrics { get; set; }
        public SmartPolesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Name = "Renan",
                Username = "renan",
                Salt = "4c87a8c92dd5186d2875d7c06ffd020566f77d226f1d0ec53d860e65aceffbbd",
                Password = "H/i+2c/uXaaBwdCfZ8L0jzyQHzdpIn2QYqt7YAQBpVI=",
                Id = Guid.Parse("50e56a44-d975-4fec-a39c-0ae009a2be95")
            });

            modelBuilder.Entity<Condominium>().HasData(new Condominium()
            {
                Id = Guid.Parse("c88cdc3a-6b82-460b-9356-dc63847aa437"),
                Name = "Condominio 1",
                City = "São Bernardo do Campo",
                Image = "teste"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
