using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entity;
using Restaurant.Infra.Configuration;
using System.Linq;

namespace Restaurant.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(DatabaseConnection.GetConnection());
            else
                base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Order> Order { get; set; }
    }
}
