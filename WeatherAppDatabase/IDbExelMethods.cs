using WeatherAppDatabase.Models;

namespace WeatherAppDatabase
{
    public interface IDbExelMethods
    {
        public void SetWorkbookAndSheet(string path);
        public string GetCellData(string path, int rowNum, int cellNum);
        public string GetArchiveHeader(string path);
        public string GetArchiveDescription(string path);
        public string GetColumnName(string path, int columnNum);
        public List<string> GetRowData(string path,int rowNum);
        public List<string> GetColumnData(string path, int columnNum);
        public List<ColumnName> GetColumnNames(string path);
        public List<Date> GetDates(string path);
        public List<Time> GetTimes(string path);
        public List<Temperature> GetTemperatures(string path);
        public List<RelativeHumidity> GetRelativeHumidities(string path);
        public List<TD> GetTDs(string path);
        public List<AtmosphericPressure> GetAtmosphericPressures(string path);
        public List<WindDirection> GetWindDirections(string path);
        public List<WindSpeed> GetWindSpeeds(string path);
        public List<Cloudiness> GetCloudinesses(string path);
        public List<H> GetHs(string path);
        public List<VV> GetVVs(string path);
        public List<WeatherPhenomen> GetWeatherPhenomenas(string path);
        public void SetAllData(string path);
       
    }
}
