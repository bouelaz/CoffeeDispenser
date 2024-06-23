using CoffeeDispenser.API.Models;

namespace CoffeeDispenser.API.Services
{
    public interface ICalculationPriceStrategyService
    {
        decimal CalculateFinalPrice(Drink drink);
    }
}
