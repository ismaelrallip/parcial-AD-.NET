using Microsoft.EntityFrameworkCore;
using Rallip.Domain.Model;

namespace Rallip.Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Alquiler> Alquileres { get; set; }

        public TPIContext(DbContextOptions<TPIContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dbAlquiler;Trusted_Connection=True;TrustServerCertificate=True;"); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); 
                entity.Property(e => e.Inquilino).IsRequired().HasMaxLength(150); 
            });
        }
    }
}