using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class ExcelAccess<T>
    {
        public virtual ICollection<T> GetSheetData(string path, string sheetName)
        {
            using (Stream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];
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
