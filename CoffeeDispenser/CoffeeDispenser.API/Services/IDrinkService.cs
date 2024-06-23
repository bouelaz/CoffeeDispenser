using CoffeeDispenser.API.Dtos;
using CoffeeDispenser.API.Models;

namespace CoffeeDispenser.API.Services
{
    public interface IDrinkService
    {
        Task<List<DrinkDto>> GetAllDrinksAsync();
        Task<DrinkDto> GetDrinkWithDetails(int drinkId);
        Task<decimal> GetDrinPriceById(int drinkId);
    }
}
