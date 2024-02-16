using Microsoft.EntityFrameworkCore;
using WeatherCheckerUploader.Db.Models;

namespace WeatherCheckerUploader.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DbWeatherArchiveModel> dbWeatherArchiveModels { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
