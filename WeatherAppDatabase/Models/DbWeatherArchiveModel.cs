using Microsoft.EntityFrameworkCore;

namespace WeatherAppDatabase.Models
{
    public class DbWeatherArchiveModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<ColumnName> ColumnNames { get; set; }
        public List<Date> Dates { get; set; }
        //public List<string> Times { get; set; }
        //public List<string> Temperatures { get; set; }
        //public List<string> RelativeHumidities { get; set; }
        //public List<string> TDs { get; set; }
        //public List<string> AtmosphericPressures { get; set; }
        //public List<string> WindDirections { get; set; }
        //public List<string> WindSpeeds { get; set; }
        //public List<string> Cloudinesses { get; set; }
        //public List<string> Hs { get; set; }
        //public List<string> VVs { get; set; }
        //public List<string> WeatherPhenomenas { get; set; }

    }
}
