using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Linq;
using WeatherAppDatabase.Models;

namespace WeatherAppDatabase.WorkWithExel
{
    public class DbExelMethods : IDbExelMethods
    {
        private readonly DatabaseContext dbContext;
        const int numbersOfColumns = 12;
        IWorkbook workbook;
        ISheet sheet;
        public DbExelMethods(DatabaseContext dbContext)
        {
            using (FileStream fileStream = new FileStream("C:\\Users\\DlyaS\\OneDrive\\Рабочий стол\\Все\\IT\\Проекты\\WeatherCheckerUploader_TestTask\\WeatherCheckerUploader\\WeatherCheckerUploader\\WeatherArchives\\moskva_2010.xlsx", FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fileStream);
            }
            sheet = workbook.GetSheetAt(0); // Получение листа
            this.dbContext = dbContext;
        }
        public string GetCellData(int rowNum, int cellNum)
        {
            IRow row = sheet.GetRow(rowNum); // строка
            string cell = row.GetCell(cellNum)?.ToString(); // ячейка (столбец)
            return cell;
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
        public List<ColumnName> GetColumnNames()
        {
            var columnNames = new List<ColumnName>();
            for (int i = 0; i < numbersOfColumns; i++)
            {
                columnNames.Add(new ColumnName { Id = new Guid(), Name = GetColumnName(i) });
            }
            return columnNames;
        }
        public List<Temperatures> GetDates()
        {
            var dates = new List<Temperatures>();
            foreach (var el in GetColumnData(0))
            {
                if (dates.FirstOrDefault(i => i.Value == el) == null && dbContext.dates.FirstOrDefault(i => i.Value == el) == null)
                {
                    dates.Add(new Temperatures { Id = new Guid(), Value = el });
                }
                else if (dates.FirstOrDefault(i => i.Value == el) != null)
                {
                    dates.Add(dates.FirstOrDefault(i => i.Value == el));
                }
                else
                { 
                    dates.Add(dbContext.dates.FirstOrDefault(i => i.Value == el)); 
                }
            }
            return dates;
        }
        public void SetAllData(DbWeatherArchiveModel model)
        {
            model.Name = "msk_2010";
            model.Header = GetArchiveHeader();
            model.Description = GetArchiveDescription();
            model.ColumnNames = GetColumnNames();
            model.Dates = GetDates();
            //model.Times = GetColumnData(1);
            //model.Temperatures = GetColumnData(2);
            //model.RelativeHumidities = GetColumnData(3);
            //model.TDs = GetColumnData(4);
            //model.AtmosphericPressures = GetColumnData(5);
            //model.WindDirections = GetColumnData(6);
            //model.WindSpeeds = GetColumnData(7);
            //model.Cloudinesses = GetColumnData(8);
            //model.Hs = GetColumnData(9);
            //model.VVs = GetColumnData(10);
            //model.WeatherPhenomenas = GetColumnData(11);
            dbContext.dbWeatherArchiveModels.Add(model);
            dbContext.SaveChanges();
        }
    }
}
