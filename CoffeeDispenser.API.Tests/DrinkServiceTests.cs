using CoffeeDispenser.API.Data;
using CoffeeDispenser.API.Models;
using CoffeeDispenser.API.Repositories;
using CoffeeDispenser.API.Services;
using CoffeeDispenser.API.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace CoffeeDispenser.API.Tests
{
    [Collection("Drinks")]
    public class DrinkServiceTests
    { 
        private readonly IGenericRepository<Drink> _drinkRepository;
        private readonly ICalculationPriceStrategyService _priceStrategyService;
        private readonly ILogger<DrinkService> _logger;
        private readonly DrinkService _drinkService;

        public DrinkServiceTests(DatabaseFixture fixture)
        { 
   
            _drinkRepository = Substitute.ForPartsOf<GenericRepository<Drink>>(fixture.DbContext);
            _logger = Substitute.For<ILogger<DrinkService>>();
            _priceStrategyService = Substitute.ForPartsOf<CalculationPriceStrategyService>();
            _drinkService = new DrinkService(_drinkRepository, _logger, _priceStrategyService);
        }

        [Fact]
        public async Task GetAllDrinks_ReturnsCorrectDrinkDtosAsync()
        {
            // Arrange   + Act
            var result = await _drinkService.GetAllDrinksAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal("Espresso", result[0].Name);
            Assert.Equal(0.84m, result[0].Price);
            Assert.Equal("Latte", result[1].Name);
            Assert.Equal(0.72m, result[1].Price);
        }


    }
}