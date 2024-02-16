using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WeatherCheckerUploader.WorkWithExel
{
    public class ExelMethods
    {
        const string path = "WeatherArchives/moskva_2010.xlsx";
        const int columns = 12;

        public string GetCellData(int rowNum, int cellNum)
        {
            IWorkbook workbook;
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fileStream);
            }

            // Получение листа
            ISheet sheet = workbook.GetSheetAt(0);
            // Чтение данных из ячейки
            IRow row = sheet.GetRow(rowNum); // строка
            string cell = row.GetCell(cellNum)?.ToString(); // ячейка (столбец)
            return cell;
        }
        public List<string> GetRowData(int rowNum)
        {
            var rowElems = new List<string>();
            for (int i = 0; i < columns; i++)
            {
                rowElems.Add(GetCellData(rowNum, i));
            }
            return rowElems;
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
            return GetCellData(columnNum, 0);
        }
        public List<string> GetColumnsNames()
        {
            var columnNames = new List<string>();
            for (int i = 0; i < columns;i++)
            {
                var columnName = GetCellData(2, i) + " " + GetCellData(3, i);
                columnNames.Add(columnName);
            }
            return columnNames;
        }
    }
}
