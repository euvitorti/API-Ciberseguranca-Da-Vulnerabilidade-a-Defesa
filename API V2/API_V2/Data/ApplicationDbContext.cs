using API_V2.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace API_V2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}