using WeatherAppDatabase.Models;

namespace WeatherAppDatabase
{
    public interface IDbExelMethods
    {
        public string GetCellData(int rowNum, int cellNum);
        public List<string> GetRowData(int rowNum);
        public List<string> GetColumnData(int columnNum);
        public List<ColumnName> GetColumnNames();
        public string GetArchiveHeader();        
        public string GetArchiveDescription();
        public string GetColumnName(int columnNum);
        public void SetAllData(DbWeatherArchiveModel model);
       
    }
}
