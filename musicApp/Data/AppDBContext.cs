using Microsoft.EntityFrameworkCore;
using PodcastAPI.Models;

namespace PodcastAPI.Data
{
    public class AppDbContext : DbContext
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
        }


        public DbSet<Content> Contents { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Content_Creator> Content_Creators { get; set; }
    }
}
