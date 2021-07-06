using OfficeOpenXml;

namespace OneView_MappingSet_MVVM.DataAccess
{
    using OneView_MappingSet_MVVM.Model;

    public class SheetNamesExcelAccess : ExcelAccess<ExcelSheetName>
    {
        protected override ExcelSheetName GetExcelData(ExcelPackage package)
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
