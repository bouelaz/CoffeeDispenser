using CoffeeDispenser.API.Dtos;
using CoffeeDispenser.API.Models;
using System.Linq;

namespace CoffeeDispenser.API.Mappers
{
    public static class DrinkMapper
    {
        public static DrinkDto MapToDto(this Drink drink, decimal price)
        {
            if (drink == null)
                return null;

            return new DrinkDto
            {
                Id = drink.Id,
                Name = drink.Name,
                Description = drink.Description,
                TotalCost = drink.DrinkIngredients.Sum(x => x.Quantity * x.Ingredient.PricePerUnit),
                Price = price,
                Ingredients = MapIngredients(drink.DrinkIngredients)
            };
        }


        private static List<IngredientDto> MapIngredients(ICollection<DrinkIngredient> drinkIngredients)
        {
            if (drinkIngredients == null)
                return null;

            return drinkIngredients
                .Select(drinkIngredient => new IngredientDto
                {
                    Name = drinkIngredient.Ingredient.Name,
                    PricePerUnit = drinkIngredient.Ingredient.PricePerUnit,
                    Units = drinkIngredient.Quantity
                })
                .ToList();
        }
    }
}
