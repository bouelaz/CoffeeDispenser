using CoffeeDispenser.API.Models;

namespace CoffeeDispenser.API.Services
{
    public class CalculationPriceStrategyService : ICalculationPriceStrategyService
    {
        private const decimal MarkupPercentage = 0.30m;

        private decimal ApplyMarkupPrice(decimal price) => price * (1 + MarkupPercentage);

        public decimal CalculateFinalPrice(Drink drink)
        {
            decimal price = drink.DrinkIngredients.Sum(di => ApplyMarkupPrice(di.Quantity * di.Ingredient.PricePerUnit));
 
            var finalPrice = Math.Round(price, 2);

            return  finalPrice;
        }
    }
}
