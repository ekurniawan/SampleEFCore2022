using Microsoft.EntityFrameworkCore;
using SampleEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data
{
    public class SwordContext : DbContext
    {
        //dotnet ef migrations add initial --context SwordContext -o MigrationsSword
        //dotnet ef database update --context SwordContext

        public DbSet<Sword> Swords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SwordDb")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
        }
    }
}
