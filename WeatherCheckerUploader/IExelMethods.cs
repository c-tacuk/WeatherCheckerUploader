using NPOI.SS.UserModel;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader
{
    public interface IExelMethods
    {
        public string GetCellData(int rowNum, int cellNum);
        public List<string> GetRowData(int rowNum);
        public List<string> GetColumnData(int columnNum);
        public string GetArchiveHeader();        
        public string GetArchiveDescription();
        public string GetColumnName(int columnNum);
        public List<string> GetColumnNames();
        public void SetAllData(WeatherArchiveModel model);
       
    }
}
