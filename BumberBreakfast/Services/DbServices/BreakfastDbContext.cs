using BumberBreakfast.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BumberBreakfast.Services.DbServices
{
    public class BreakfastDbContext : DbContext
    {
        public BreakfastDbContext(DbContextOptions<BreakfastDbContext> options) : base(options) { }

        public DbSet<Breakfast> Breakfast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Breakfast>()
                    .Property(b => b.Id)
                    .HasConversion(
                        id => id.ToString(),   // Convert Guid to string
                        str => Guid.Parse(str) // Convert string to Guid
                    );
        }
    }
}
