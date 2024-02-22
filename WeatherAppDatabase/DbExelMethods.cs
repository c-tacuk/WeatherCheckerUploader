using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
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
        public List<Date> GetDates()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<Time> GetTimes()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<Temperature> GetTemperatures()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<RelativeHumidity> GetRelativeHumidities()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<TD> GetTDs()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<AtmosphericPressure> GetAtmosphericPressures()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<WindDirection> GetWindDirections()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<WindSpeed> GetWindSpeeds()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<Cloudiness> GetCloudinesses()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<H> GetHs()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<VV> GetVVs()
        {
            var dates = new List<Date>();
            foreach (var el in GetColumnData(0))
            {
                dates.Add(new Date { Id = new Guid(), Value = el });
            }
            return dates;
        }
        public List<WeatherPhenomen> GetWeatherPhenomenas()
        {
            var weatherPhenomenas = new List<WeatherPhenomen>();
            foreach (var el in GetColumnData(0))
            {
                if (el == null)
                {
                    weatherPhenomenas.Add(new WeatherPhenomen { Id = new Guid(), Value = el });
                }
                weatherPhenomenas.Add(new WeatherPhenomen { Id = new Guid(), Value = el });
            }
            return weatherPhenomenas;
        }
        public void SetAllData(DbWeatherArchiveModel model)
        {
            model.Name = "msk_2010";
            model.Header = GetArchiveHeader();
            model.Description = GetArchiveDescription();
            model.ColumnNames = GetColumnNames();
            model.Dates = GetDates();
            model.Times = GetTimes();
            model.Temperatures = GetTemperatures();
            model.RelativeHumidities = GetRelativeHumidities();
            model.TDs = GetTDs();
            model.AtmosphericPressures = GetAtmosphericPressures();
            model.WindDirections = GetWindDirections();
            model.WindSpeeds = GetWindSpeeds();
            model.Cloudinesses = GetCloudinesses();
            model.Hs = GetHs();
            model.VVs = GetVVs();
            model.WeatherPhenomenas = GetWeatherPhenomenas();
            dbContext.dbWeatherArchiveModels.Add(model);
            dbContext.SaveChanges();
        }
    }
}
