using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppDatabase.Models;

namespace WeatherAppDatabase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DbWeatherArchiveModel> dbWeatherArchiveModels { get; set; }
        public DbSet<ColumnName> columnNames { get; set; }
        public DbSet<Date> dates { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DbWeatherArchiveModel>().HasData(
        //            new DbWeatherArchiveModel { Id = new Guid(), Name = "Tom1" },
        //            new DbWeatherArchiveModel { Id = new Guid(), Name = "Tom2" },
        //            new DbWeatherArchiveModel { Id = new Guid(), Name = "Tom3" }
        //    );
        //}
    }
}
