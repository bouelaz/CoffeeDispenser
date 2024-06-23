using CoffeeDispenser.API.Services;
using CoffeeDispenser.API.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeDispenser.API.Tests
{
    public class CalculationPriceStrategyServiceTests
    {
        private readonly ICalculationPriceStrategyService _priceStrategyService;

        public CalculationPriceStrategyServiceTests()
        {
            _priceStrategyService = new CalculationPriceStrategyService();
        }

        [Theory]
        [InlineData("Espresso", 0.84)]
        [InlineData("Latte", 0.72)]
        [InlineData("Chocolat chaud", 1.24)]
        public void CalculateFinalPrice_ReturnsCorrectPrice(string drinkName, decimal expectedFinalPrice)
        {
            // Arrange
            var drink = MockDrinksData.GetDrinks().Find(x => x.Name == drinkName);

            // Act
            var result = _priceStrategyService.CalculateFinalPrice(drink);

            // Assert
            Assert.Equal(expectedFinalPrice, result);
        }
    }
}
