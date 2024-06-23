using CoffeeDispenser.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeDispenser.API.Tests.Data
{
    public class DatabaseFixture : IDisposable
    {
        public CoffeeDbContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<CoffeeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            DbContext = new CoffeeDbContext(options);
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            DbContext.AddRange(MockDrinksData.GetDrinks());
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
