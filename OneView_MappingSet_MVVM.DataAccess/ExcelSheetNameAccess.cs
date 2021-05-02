using OfficeOpenXml;

namespace OneView_MappingSet_MVVM.DataAccess
{
    using OneView_MappingSet_MVVM.Model;
    using System.IO;

    public class ExcelSheetNameAccess
    {
        public ExcelSheetName GetSheetsNames(string path)
        {
            using (Stream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelSheetName excelSheetName = new ExcelSheetName();
                    foreach (var worksheet in package.Workbook.Worksheets)
                    {
                        excelSheetName.SheetCollection.Add(worksheet.Name);
                    }
                    return excelSheetName;
                }
            }
        }
    }
}
