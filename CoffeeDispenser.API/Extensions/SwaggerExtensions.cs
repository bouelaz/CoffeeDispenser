using Microsoft.OpenApi.Models;

namespace CoffeeDispenser.API.Extensions
{
    public static class SwaggerSetup
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Coffee Dispenser API",
                    Description = "API for managing a coffee dispenser <br /> Ce projet est réalisé par <b>MZOUGHI MOEZ.</b>",
                    Contact = new OpenApiContact
                    {
                        Name = "Moez Mzoughi",
                        //Email = "your-email@example.com",
                        //Url = new Uri("https://example.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });
        }
    }
}
