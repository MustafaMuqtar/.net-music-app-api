using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using musicApp.Data.Entities;
using PodcastAPI.Models;

namespace PodcastAPI.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content_Creator>()
                .HasOne(c => c.Content)
             .WithMany(cr => cr.Content_Creators)
             .HasForeignKey(ci => ci.ContentId);


            modelBuilder.Entity<Content_Creator>()
              .HasOne(c => c.Creator)
           .WithMany(cr => cr.Content_Creators)
           .HasForeignKey(ci => ci.CreatorId);

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
                );
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Content> Contents { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Content_Creator> Content_Creators { get; set; }
    }
}
