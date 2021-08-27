using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class SourceItemListCreateExcelAccess : ExcelAccessCreate<SourceItemList>
    {
        protected override void PutExcelData(ExcelPackage package, SourceItemList data)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(MappingSetGenerator.SourceItemListSheetName);

            PrepareSheet(ws);

            ws.Cells["A1"].AutoFitColumns();
            package.Save();
        }

        private static void PrepareSheet(ExcelWorksheet ws)
        {
            ws.Cells["A1"].Value = "SourceItemIdentifier";
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["A1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(@"#FFC000"));
        }
    }
}
