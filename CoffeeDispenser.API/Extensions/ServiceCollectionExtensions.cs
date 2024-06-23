using CoffeeDispenser.API.Data;
using CoffeeDispenser.API.Repositories;
using CoffeeDispenser.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CoffeeDispenser.API.Extensions
{
    public static class ServiceCollectionExtensions
    { 
         
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext
            AddDbContext(services, configuration);

            // Configure Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Configure Services
            services.AddScoped<IDrinkService, DrinkService>();

            // Register the calculation price strategy service
            services.AddScoped<ICalculationPriceStrategyService, CalculationPriceStrategyService>();

            // Register Swagger setup method
            services.ConfigureSwagger();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CoffeeDispenserDb");
            services.AddDbContext<CoffeeDbContext>(options =>
            {
                if (connectionString == "InMemory")
                {
                    options.UseInMemoryDatabase("CoffeeDispenser");
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });
        }
    }
    
}
