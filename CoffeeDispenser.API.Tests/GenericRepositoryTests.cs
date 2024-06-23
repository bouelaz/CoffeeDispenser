using CoffeeDispenser.API.Data;
using CoffeeDispenser.API.Models;
using CoffeeDispenser.API.Repositories;
using CoffeeDispenser.API.Tests.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeDispenser.API.Tests
{
    [Collection("Drinks")]
    public class GenericRepositoryTests
    {
        private readonly CoffeeDbContext _dbContext;
        private readonly IGenericRepository<Drink> _repository;

        public GenericRepositoryTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _repository = new GenericRepository<Drink>(_dbContext);
        }


        [Fact]
        public async Task GetByIdAsync_Returns_Entity()
        {
            // Arrange
            var expectedDrink = new Drink { Id = 1, Name = "Drink 1" };

            // Act
            var result = await _repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDrink.Id, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_Returns_All_Entities()
        {
            // Arrange + Act
            var result = await _repository.GetAll().CountAsync();

            // Assert
            Assert.Equal(_dbContext.Drinks.Count(), result);
        }

        [Fact]
        public async Task AddAsync_Adds_New_Drink()
        {
            // Arrange
            var newDrink = new Drink
            {
                Id = 4,
                Name = "New Drink",
                Description = "Dricnk info",
                DrinkIngredients =
                [
                    new DrinkIngredient
                    {

                      Ingredient = new Ingredient
                        {
                            Name = "Coffee",
                            PricePerUnit  = 0.30m
                        },
                        Quantity = 2
                    },

                ]

            };

            // Act
            await _repository.Add(newDrink);
            // Assert
            var result = await _dbContext.Drinks.FindAsync(4);
            Assert.Equal(newDrink.Id, result.Id);
        }
    }
}
