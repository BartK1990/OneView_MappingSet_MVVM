using OfficeOpenXml;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class SheetDataExcelAccess<T> : ExcelAccess<T>
    {
        protected string SheetName;
        protected int MaxColNum;

        protected override T GetExcelData(ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[SheetName];
            return ReadSheetData(worksheet, worksheet.Dimension.Rows, worksheet.Dimension.Columns);
        }

        protected abstract T ReadSheetData(ExcelWorksheet worksheet, int rows, int columns);

        protected string GetCellValue(object cell)
        {
            if (cell == null)
                return string.Empty;
            return cell.ToString();
        }
    }
}
