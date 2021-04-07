using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class ExcelAccess<T>
    {
        protected string SheetName;
        protected int MaxColNum;

        protected virtual ICollection<T> GetSheetData(string path)
        {
            using (Stream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[SheetName];
                    return ReadSheetData(worksheet, worksheet.Dimension.Rows, worksheet.Dimension.Columns);
                }
            }
        }

        protected virtual ICollection<T> ReadSheetData(ExcelWorksheet worksheet, int rows, int columns)
        {
            return null;
        }

        protected string GetCellValue(object cell)
        {
            if (cell == null)
                return string.Empty;
            return cell.ToString();
        }
    }
}
