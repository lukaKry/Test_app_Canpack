using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_app_consoleApp
{
    class TestDatabaseContext : DbContext
    {
        public DbSet<DatabaseDataModel> DatabaseRecords { get; set; }

        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options) : base(options)
        { }
    }
}
