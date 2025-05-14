using Microsoft.EntityFrameworkCore;
using st10161149_prog7311_part2.Models;
using System.Collections.Generic;

namespace st10161149_prog7311_part2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User-Farmer one-to-one relationship
            modelBuilder.Entity<Farmer>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Farmer-Product one-to-many relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Farmer)
                .WithMany()
                .HasForeignKey(p => p.FarmerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    }
