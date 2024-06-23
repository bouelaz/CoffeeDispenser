using CoffeeDispenser.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeDispenser.API.Data
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options) { }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DrinkIngredient> DrinkIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrinkIngredient>()
                .HasKey(di => new { di.DrinkId, di.IngredientId });

            modelBuilder.Entity<DrinkIngredient>()
                .HasOne(di => di.Drink)
                .WithMany(d => d.DrinkIngredients)
                .HasForeignKey(di => di.DrinkId);

            modelBuilder.Entity<DrinkIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DrinkIngredients)
                .HasForeignKey(di => di.IngredientId);
        }
    }
} 