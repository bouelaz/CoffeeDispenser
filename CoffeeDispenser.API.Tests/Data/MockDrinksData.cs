using CoffeeDispenser.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeDispenser.API.Tests.Data
{
    public class MockDrinksData
    {
        public static List<Drink> GetDrinks()
        {
            var espresso = new Drink
            {
                Id = 1,
                Name = "Espresso",
                Description = "Strong coffee",
                DrinkIngredients =
                [
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Coffee", PricePerUnit  = 0.30m },Quantity = 2},
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Water", PricePerUnit = 0.05m },Quantity = 1}
                ]
            };

            var latte = new Drink
            {
                Id = 2,
                Name = "Latte",
                Description = "Coffee with milk",
                DrinkIngredients =
                [
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Coffee", PricePerUnit = 0.30m },Quantity = 1},
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Milk", PricePerUnit = 0.10m },Quantity = 2},
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Water", PricePerUnit = 0.05m },Quantity = 1}
                ]
            };
            var chocolat = new Drink
            {
                Id = 3,
                Name = "Chocolat chaud",
                Description = "Hot chocolate",
                DrinkIngredients =
                [
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Chocolat", PricePerUnit  = 0.40m },Quantity = 2},
                    new DrinkIngredient{Ingredient = new Ingredient { Name = "Eau", PricePerUnit = 0.05m },Quantity = 3}
                ]
            };
            return [espresso, latte, chocolat];
        }
    }
}
