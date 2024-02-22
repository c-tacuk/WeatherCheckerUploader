using Microsoft.EntityFrameworkCore;

namespace WeatherAppDatabase.Models
{
    public class DbWeatherArchiveModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = "path";
        public string Name { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<ColumnName> ColumnNames { get; set; }
        public List<Date> Dates { get; set; }
        public List<Time> Times { get; set; }
        public List<Temperature> Temperatures { get; set; }
        public List<RelativeHumidity> RelativeHumidities { get; set; }
        public List<TD> TDs { get; set; }
        public List<AtmosphericPressure> AtmosphericPressures { get; set; }
        public List<WindDirection> WindDirections { get; set; }
        public List<WindSpeed> WindSpeeds { get; set; }
        public List<Cloudiness> Cloudinesses { get; set; }
        public List<H> Hs { get; set; }
        public List<VV> VVs { get; set; }
        public List<WeatherPhenomen> WeatherPhenomenas { get; set; }

    }
}
