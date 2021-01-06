using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PokemonDb.Models
{
    public class PokemonDbContextFactory : IDesignTimeDbContextFactory<PokemonDbContext>
    {

        PokemonDbContext IDesignTimeDbContextFactory<PokemonDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PokemonDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new PokemonDbContext(builder.Options);
        }
    }
}