using Microsoft.EntityFrameworkCore;
using MyWebPage.Models;


namespace MyWebPage.Data
{
    public class ProjectsDatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ProjectsDatabaseContext() { }
        public ProjectsDatabaseContext(DbContextOptions<ProjectsDatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Project>().ToTable("Project");
        }
    }
}
