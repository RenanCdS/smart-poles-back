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
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasData(new User()
            {
                Name = "Renan",
                Username = "Renan123",
                Salt = "vPMp64vr/XTFMXuPxEeOFA==",
                CondominiumId = Guid.Parse("c88cdc3a-6b82-460b-9356-dc63847aa437"),
                Password = "MOdh2zu4pG6TNeF2e55Wm8R/GDU4oAdqSKuN6pq3G0w=",
                Id = Guid.Parse("50e56a44-d975-4fec-a39c-0ae009a2be95"),
                Role = CrossCutting.Enums.Role.NORMAL
            },
            new User()
            {
                Name = "Juninho",
                Username = "Juninho123",
                Salt = "nGGBzd9L28ZCCUoujvw18Q==",
                CondominiumId = Guid.Parse("c88cdc3a-6b82-460b-9356-dc63847aa437"),
                Password = "qK9focZZPN8c+7l7dunJwW0dLdnXOFxpiRXGNj2PMr0=",
                Id = Guid.Parse("378cc1b9-6789-4c5d-b2c9-a99c7ebe3f7a"),
                Role = CrossCutting.Enums.Role.NORMAL
            },
            new User()
            {
                Name = "Betina",
                Username = "Betina123",
                Salt = "v2eYortZiRuSUGhGPZV90w==",
                CondominiumId = Guid.Parse("922b5292-a5bc-4e89-8f33-286c88582a59"),
                Password = "0eWGHK2LE00RPzS5PJVULOVRDJSo72U4in8q0+WSVLg=",
                Id = Guid.Parse("735332f6-0918-4c6c-bd12-23cc7cd58991"),
                Role = CrossCutting.Enums.Role.ADM
            });

            modelBuilder.Entity<Condominium>().HasData(new Condominium()
            {
                Id = Guid.Parse("c88cdc3a-6b82-460b-9356-dc63847aa437"),
                Name = "Condominio Thera",
                City = "São Bernardo do Campo",
                Image = "teste"
            },
            new Condominium()
            {
                Id = Guid.Parse("922b5292-a5bc-4e89-8f33-286c88582a59"),
                Name = "Alphaville place",
                City = "São Paulo",
                Image = "teste"
            },
            new Condominium()
            {
                Id = Guid.Parse("52191423-1a89-4340-8915-b233a50d7df7"),
                Name = "Alvorada palace",
                City = "Santo André",
                Image = "teste"
            });

            modelBuilder.Entity<Pole>().HasData(new Pole()
            {
                CondominiumId = Guid.Parse("922b5292-a5bc-4e89-8f33-286c88582a59"),
                Id = Guid.Parse("6ec1b29e-b724-45a3-abf3-979c4d334ec2"),
                IsGateway = false
            },
            new Pole()
            {
                CondominiumId = Guid.Parse("922b5292-a5bc-4e89-8f33-286c88582a59"),
                Id = Guid.Parse("e95f0b3c-56c7-479a-be71-96e3f9e0f08e"),
                IsGateway = true
            },
            new Pole()
            {
                CondominiumId = Guid.Parse("922b5292-a5bc-4e89-8f33-286c88582a59"),
                Id = Guid.Parse("47d4ceda-4cc3-4ac1-9452-e799eb3311f1"),
                IsGateway = false
            },
            new Pole()
            {
                CondominiumId = Guid.Parse("c88cdc3a-6b82-460b-9356-dc63847aa437"),
                Id = Guid.Parse("dc139029-862c-41a8-bfd7-0067ea9c42a1"),
                IsGateway = false
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
