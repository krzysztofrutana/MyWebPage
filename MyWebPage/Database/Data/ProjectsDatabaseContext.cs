using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MyWebPage.Models;
using System;

namespace MyWebPage.Data
{
    public class ProjectsDatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ProjectsDatabaseContext(DbContextOptions<ProjectsDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
        }
    }
}
