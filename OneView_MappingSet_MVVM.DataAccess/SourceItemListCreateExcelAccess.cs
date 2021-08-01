using OfficeOpenXml;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class SourceItemListCreateExcelAccess : ExcelAccessCreate<SourceItemList>
    {
        protected override SourceItemList ReadWriteExcelData(ExcelPackage package)
        {
            package.Workbook.Worksheets.Add(MappingSetGenerator.SourceItemListSheetName);
            return null;
        }
    }
}
