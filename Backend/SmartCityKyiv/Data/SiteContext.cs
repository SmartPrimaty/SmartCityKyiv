using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartCityKyiv.Models;
using System.Security.Cryptography;
using System.Text;

namespace SmartCityKyiv.Data
{
    public class SiteContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public SiteContext(DbContextOptions<SiteContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role);

            var roles = new Role[]
            {
                new Role()
                {
                    Id = 1,
                    Name = "admin",
                },
                new Role()
                {
                    Id = 2,
                    Name = "moderator"
                }
            };

            var password = CreateHash("admin");
            var admin = new User()
            {
                Email = "admin@smartcitykyiv.ua",
                Password = password,
                Name = "Administrator",
                Role = roles[0],
                RoleId = 1
            };

            modelBuilder.Entity<Role>()
                .HasData(roles);

            modelBuilder.Entity<User>()
                .HasData(admin);
        }


        private string CreateHash(string source)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            byte[] targerBytes = sha256.ComputeHash(sourceBytes);
            string target = Encoding.UTF8.GetString(targerBytes);
            return target;
        }
    }
}
