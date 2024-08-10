using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using MyAppDb.Models;
using System.Security.Cryptography;
namespace MyAppDb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Crop> Crop { get; set; }
        public DbSet<Bids> Bids { get; set; }
        public DbSet<Admin> Admin{ get; set; }
        public DbSet<UserCrop> UserCrops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User-Crop many-to-many relationship
            modelBuilder.Entity<UserCrop>()
                .HasKey(uc => new { uc.UserId, uc.CropId });

            modelBuilder.Entity<UserCrop>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCrop)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserCrop>()
                .HasOne(uc => uc.Crop)
                .WithMany(c => c.UserCrop)
                .HasForeignKey(uc => uc.CropId)
                .OnDelete(DeleteBehavior.NoAction);

            // User-Bid relationship (one-to-many)
            modelBuilder.Entity<Bids>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Crop-Bid relationship (one-to-many)
            modelBuilder.Entity<Bids>()
                .HasOne(b => b.Crop)
                .WithMany(c => c.Bids)
                .HasForeignKey(b => b.CropId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
