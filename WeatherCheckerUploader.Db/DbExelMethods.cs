using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeatherCheckerUploader.Db.Models;

namespace WeatherCheckerUploader.Db
{

    public class DbExelMethods
    {
        private readonly DatabaseContext databaseContext;
        const int numbersOfColumns = 12;
        IWorkbook workbook;
        ISheet sheet;
        public DbExelMethods(DatabaseContext databaseContext, string path)
        {
            this.databaseContext = databaseContext;
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fileStream);
            }
            sheet = workbook.GetSheetAt(0); // Получение листа
        }
        public string GetCellData(int rowNum, int cellNum)
        {
            IRow row = sheet.GetRow(rowNum); // строка
            string cell = row.GetCell(cellNum)?.ToString(); // ячейка (столбец)
            return cell;
        }
        public List<string> GetRowData(int rowNum)
        {
            IRow row = sheet.GetRow(rowNum);
            return row.Cells?.Select(i => i.ToString()).ToList();
        }
        public List<string> GetColumnData(int columnNum)
        {
            var lastRowNum = workbook.GetSheetAt(0).LastRowNum;
            var columnData = new List<string>();
            for (int i = 4; i <= lastRowNum; i++)
            {
                columnData.Add(GetCellData(i, columnNum));
            }
            return columnData;
        }
        public string GetArchiveHeader()
        {
            return GetCellData(0, 0);
        }
        public string GetArchiveDescription()
        {
            return GetCellData(1, 0);
        }
        public string GetColumnName(int columnNum)
        {
            return GetCellData(2, columnNum) + GetCellData(3, columnNum);
        }
        public List<string> GetColumnNames()
        {
            var columnNames = new List<string>();
            for (int i = 0; i < numbersOfColumns; i++)
            {
                columnNames.Add(GetColumnName(i));
            }
            return columnNames;
        }
        public void SetAllData(DbWeatherArchiveModel model)
        {
            model.Header = GetArchiveHeader();
            model.Description = GetArchiveDescription();
            model.ColumnNames = GetColumnNames();
            model.Dates = GetColumnData(0);
            model.Times = GetColumnData(1);
            model.Temperatures = GetColumnData(2);
            model.RelativeHumidities = GetColumnData(3);
            model.TDs = GetColumnData(4);
            model.AtmosphericPressures = GetColumnData(5);
            model.WindDirections = GetColumnData(6);
            model.WindSpeeds = GetColumnData(7);
            model.Cloudinesses = GetColumnData(8);
            model.Hs = GetColumnData(9);
            model.VVs = GetColumnData(10);
            model.WeatherPhenomenas = GetColumnData(11);

            databaseContext.dbWeatherArchiveModels.Add(model);
            databaseContext.SaveChanges();
        }
    }
}
