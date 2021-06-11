using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Test_app_consoleApp
{
    class TestDatabaseContextFactory : IDesignTimeDbContextFactory<TestDatabaseContext>
    {
        public TestDatabaseContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<TestDatabaseContext>();
            optionsBuilder
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new TestDatabaseContext(optionsBuilder.Options);
        }
    }
}
