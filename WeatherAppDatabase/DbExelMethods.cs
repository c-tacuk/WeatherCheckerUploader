using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using System.IO;
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
            this.dbContext = dbContext;
        }
        public void SetWorkbookAndSheet(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fileStream);
            }
            sheet = workbook.GetSheetAt(0); // Получение листа
        }
        public string GetCellData(string path, int rowNum, int cellNum)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            IRow? row = sheet?.GetRow(rowNum); // строка
            string? cell = row?.GetCell(cellNum)?.ToString(); // ячейка (столбец)
            return cell;
        }
        public string GetArchiveHeader(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            return GetCellData(path, 0, 0);
        }
        public string GetArchiveDescription(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            return GetCellData(path, 1, 0);
        }
        public string GetColumnName(string path, int columnNum)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            return GetCellData(path, 2, columnNum) + GetCellData(path, 3, columnNum);
        }
        public List<string> GetRowData(string path, int rowNum)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            IRow? row = sheet?.GetRow(rowNum);
            return row.Cells.Select(i => i.ToString()).ToList();
        }
        public List<string> GetColumnData(string path, int columnNum)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var lastRowNum = workbook.GetSheetAt(0).LastRowNum;
            var columnData = new List<string>();
            for (int i = 4; i <= lastRowNum; i++)
            {
                columnData.Add(GetCellData(path, i, columnNum));
            }
            return columnData;
        }
        public List<ColumnName> GetColumnNames(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var columnNames = new List<ColumnName>();
            for (int i = 0; i < numbersOfColumns; i++)
            {
                columnNames.Add(new ColumnName { Id = new Guid(), Name = GetColumnName(path, i) });
            }
            return columnNames;
        }
        public List<Date> GetDates(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var dates = new List<Date>();
            foreach (var el in GetColumnData(path, 0))
            {
                if (el == null)
                {
                    dates.Add(new Date { Id = new Guid(), Value = "null" });
                }
                else
                {
                    dates.Add(new Date { Id = new Guid(), Value = el });
                }
            }
            return dates;
        }
        public List<Time> GetTimes(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var times = new List<Time>();
            foreach (var el in GetColumnData(path, 1))
            {
                if (el == null)
                {
                    times.Add(new Time { Id = new Guid(), Value = "null" });
                }
                else
                {
                    times.Add(new Time { Id = new Guid(), Value = el });
                }
            }
            return times;
        }
        public List<Temperature> GetTemperatures(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var temperatures = new List<Temperature>();
            foreach (var el in GetColumnData(path, 2))
            {
                if (el == null)
                {
                    temperatures.Add(new Temperature { Id = new Guid(), Value = "null" });
                }
                else
                {
                    temperatures.Add(new Temperature { Id = new Guid(), Value = el });
                }
            }
            return temperatures;
        }
        public List<RelativeHumidity> GetRelativeHumidities(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var relativeHumidities = new List<RelativeHumidity>();
            foreach (var el in GetColumnData(path, 3))
            {
                if (el == null)
                {
                    relativeHumidities.Add(new RelativeHumidity { Id = new Guid(), Value = "null" });
                }
                else
                {
                    relativeHumidities.Add(new RelativeHumidity { Id = new Guid(), Value = el });
                }
            }
            return relativeHumidities;
        }
        public List<TD> GetTDs(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var TDs = new List<TD>();
            foreach (var el in GetColumnData(path, 4))
            {
                if (el == null)
                {
                    TDs.Add(new TD { Id = new Guid(), Value = "null" });
                }
                else
                {
                    TDs.Add(new TD { Id = new Guid(), Value = el });
                }
            }
            return TDs;
        }
        public List<AtmosphericPressure> GetAtmosphericPressures(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var atmosphericPressures = new List<AtmosphericPressure>();
            foreach (var el in GetColumnData(path, 5))
            {
                if (el == null)
                {
                    atmosphericPressures.Add(new AtmosphericPressure { Id = new Guid(), Value = "null" });
                }
                else
                {
                    atmosphericPressures.Add(new AtmosphericPressure { Id = new Guid(), Value = el });
                }
            }
            return atmosphericPressures;
        }
        public List<WindDirection> GetWindDirections(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var windDirections = new List<WindDirection>();
            foreach (var el in GetColumnData(path, 6))
            {
                if (el == null)
                {
                    windDirections.Add(new WindDirection { Id = new Guid(), Value = "null" });
                }
                else
                {
                    windDirections.Add(new WindDirection { Id = new Guid(), Value = el });
                }
            }
            return windDirections;
        }
        public List<WindSpeed> GetWindSpeeds(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var windSpeeds = new List<WindSpeed>();
            foreach (var el in GetColumnData(path, 7))
            {
                if (el == null)
                {
                    windSpeeds.Add(new WindSpeed { Id = new Guid(), Value = "null" });
                }
                else
                {
                    windSpeeds.Add(new WindSpeed { Id = new Guid(), Value = el });
                }
            }
            return windSpeeds;
        }
        public List<Cloudiness> GetCloudinesses(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var cloudinesses = new List<Cloudiness>();
            foreach (var el in GetColumnData(path, 8))
            {
                if (el == null)
                {
                    cloudinesses.Add(new Cloudiness { Id = new Guid(), Value = "null" });
                }
                else
                {
                    cloudinesses.Add(new Cloudiness { Id = new Guid(), Value = el });
                }
            }
            return cloudinesses;
        }
        public List<H> GetHs(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var Hs = new List<H>();
            foreach (var el in GetColumnData(path, 9))
            {
                if (el == null)
                {
                    Hs.Add(new H { Id = new Guid(), Value = "null" });
                }
                else
                {
                    Hs.Add(new H { Id = new Guid(), Value = el });
                }
            }
            return Hs;
        }
        public List<VV> GetVVs(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var VVs = new List<VV>();
            foreach (var el in GetColumnData(path, 10))
            {
                if (el == null)
                {
                    VVs.Add(new VV { Id = new Guid(), Value = "null" });
                }
                else
                {
                    VVs.Add(new VV { Id = new Guid(), Value = el });
                }
            }
            return VVs;
        }
        public List<WeatherPhenomen> GetWeatherPhenomenas(string path)
        {
            if (workbook == null || sheet == null) { SetWorkbookAndSheet(path); }

            var weatherPhenomenas = new List<WeatherPhenomen>();
            foreach (var el in GetColumnData(path, 11))
            {
                if (el == null || el == "")
                {
                    weatherPhenomenas.Add(new WeatherPhenomen { Id = new Guid(), Value = "null" });
                }
                else
                {
                    weatherPhenomenas.Add(new WeatherPhenomen { Id = new Guid(), Value = el });
                }
            }
            return weatherPhenomenas;
        }
        public void SetAllData(string path)
        {
            SetWorkbookAndSheet(path);
            var model = new DbWeatherArchiveModel();
            model.Name = sheet.SheetName;
            model.Header = GetArchiveHeader(path);
            model.Description = GetArchiveDescription(path);
            model.ColumnNames = GetColumnNames(path);
            model.Dates = GetDates(path);
            model.Times = GetTimes(path);
            model.Temperatures = GetTemperatures(path);
            model.RelativeHumidities = GetRelativeHumidities(path);
            model.TDs = GetTDs(path);
            model.AtmosphericPressures = GetAtmosphericPressures(path);
            model.WindDirections = GetWindDirections(path);
            model.WindSpeeds = GetWindSpeeds(path);
            model.Cloudinesses = GetCloudinesses(path);
            model.Hs = GetHs(path);
            model.VVs = GetVVs(path);
            model.WeatherPhenomenas = GetWeatherPhenomenas(path);
            dbContext.dbWeatherArchiveModels.Add(model);
            dbContext.SaveChanges();
        }
    }
}
