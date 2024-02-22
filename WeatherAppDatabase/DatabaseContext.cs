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
        public DbSet<Time> times { get; set; }
        public DbSet<Temperature> temperatures { get; set; }
        public DbSet<RelativeHumidity> relativeHumidities { get; set; }
        public DbSet<TD> TDs { get; set; }
        public DbSet<AtmosphericPressure> atmosphericPressures { get; set; }
        public DbSet<WindDirection> windDirections { get; set; }
        public DbSet<WindSpeed> windSpeeds { get; set; }
        public DbSet<Cloudiness> cloudinesses { get; set; }
        public DbSet<H> Hs { get; set; }
        public DbSet<VV> VVs { get; set; }
        public DbSet<WeatherPhenomen> weatherPhenomenas { get; set; }
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
