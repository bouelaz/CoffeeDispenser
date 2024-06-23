using CoffeeDispenser.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeDispenser.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoffeeDbContext(serviceProvider.GetRequiredService<DbContextOptions<CoffeeDbContext>>()))
            {
                var logger = serviceProvider.GetRequiredService<ILogger<DbInitializer>>();

                // Ensure database is created
                context.Database.EnsureCreated();

                // If database has been seeded, return
                if (context.Ingredients.Any() || context.Drinks.Any() || context.DrinkIngredients.Any())
                {
                    logger.LogInformation("Database already seeded.");
                    return;
                }

                logger.LogInformation("Seeding database...");

                SeedData(context);

                logger.LogInformation("Database seeding complete.");
            }
        }

        private static void SeedData(CoffeeDbContext context)
        {
            // Ingredients
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Lait en poudre", PricePerUnit = 0.10m },
                new Ingredient { Name = "Café", PricePerUnit = 0.30m },
                new Ingredient { Name = "Chocolat", PricePerUnit = 0.40m },
                new Ingredient { Name = "Thé", PricePerUnit = 0.30m },
                new Ingredient { Name = "Eau", PricePerUnit = 0.05m }
            };
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();

            // Drinks
            var drinks = new List<Drink>
            {
                new Drink { Name = "Espresso", Description = "Strong coffee" },
                new Drink { Name = "Lait", Description = "Milk" },
                new Drink { Name = "Cappuccino", Description = "Coffee with milk foam" },
                new Drink { Name = "Chocolat Chaud", Description = "Hot chocolate" },
                new Drink { Name = "Café au Lait", Description = "Coffee with milk" },
                new Drink { Name = "Mokaccino", Description = "Coffee with chocolate" },
                new Drink { Name = "Thé", Description = "Tea" }
            };
            context.Drinks.AddRange(drinks);
            context.SaveChanges();

            // DrinkIngredients
            var drinkIngredients = new List<DrinkIngredient>();
            foreach (var drink in drinks)
            {
                switch (drink.Name)
                {
                    case "Espresso":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Café").Id, Quantity = 2 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 1 });
                        break;
                    case "Lait":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Lait en poudre").Id, Quantity = 2 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 1 });
                        break;
                    case "Cappuccino":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Lait en poudre").Id, Quantity = 2 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 1 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Café").Id, Quantity = 1 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Chocolat").Id, Quantity = 1 });
                        break;
                    case "Chocolat Chaud":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Chocolat").Id, Quantity = 3 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 2 });
                        break;
                    case "Café au Lait":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Lait en poudre").Id, Quantity = 1 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 2 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Café").Id, Quantity = 1 });
                        break;
                    case "Mokaccino":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Lait en poudre").Id, Quantity = 1 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 2 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Café").Id, Quantity = 1 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Chocolat").Id, Quantity = 2 });
                        break;
                    case "Thé":
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Eau").Id, Quantity = 2 });
                        drinkIngredients.Add(new DrinkIngredient { DrinkId = drink.Id, IngredientId = ingredients.Single(i => i.Name == "Thé").Id, Quantity = 1 });
                        break;
                    default:
                        break;
                }
            }
            context.DrinkIngredients.AddRange(drinkIngredients);
            context.SaveChanges();
        }
    }
}
