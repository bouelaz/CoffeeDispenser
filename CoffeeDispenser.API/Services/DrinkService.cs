using CoffeeDispenser.API.Dtos;
using CoffeeDispenser.API.Mappers;
using CoffeeDispenser.API.Models;
using CoffeeDispenser.API.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

namespace CoffeeDispenser.API.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IGenericRepository<Drink> _drinkRepository;
        private readonly ILogger<DrinkService> _logger;
        private readonly ICalculationPriceStrategyService _priceStrategyService;

        public DrinkService(
            IGenericRepository<Drink> drinkRepository,
            ILogger<DrinkService> logger,
             ICalculationPriceStrategyService priceStrategyService)
        {
            _drinkRepository = drinkRepository;
            _logger = logger;
            _priceStrategyService = priceStrategyService;
        }

        public async Task<decimal> GetDrinPriceById(int drinkId)
        {
            var drink = await GetDrinkByIdAsync(drinkId);

            var price = _priceStrategyService.CalculateFinalPrice(drink);

            return price;
        }

        public async Task<DrinkDto> GetDrinkWithDetails(int drinkId)
        {
            var drink = await GetDrinkByIdAsync(drinkId);

            decimal price = _priceStrategyService.CalculateFinalPrice(drink);

            return drink.MapToDto(price);
        }

        public async Task<List<DrinkDto>> GetAllDrinksAsync()
        {
            _logger.LogInformation("Fetching all drinks");
            var result= await GetDrinkQueryWithIncluds()
                .ToListAsync();

            return result
                .Select(d =>
                {
                    var price = _priceStrategyService.CalculateFinalPrice(d);
                   return d.MapToDto(price);
                })
                .ToList();
        }

        private async Task<Drink> GetDrinkByIdAsync(int drinkId)
        {
            return await GetDrinkQueryWithIncluds()
                .SingleOrDefaultAsync(d => d.Id == drinkId)
                ?? throw new ApplicationException($"Drink with id {drinkId} not found.");
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Drink, Ingredient> GetDrinkQueryWithIncluds()
        {
            return _drinkRepository.GetAll()
                            .Include(d => d.DrinkIngredients)
                            .ThenInclude(di => di.Ingredient);
        }
    }
}
