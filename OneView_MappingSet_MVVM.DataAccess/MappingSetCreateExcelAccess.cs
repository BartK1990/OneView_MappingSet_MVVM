using OfficeOpenXml;
using OfficeOpenXml.Style;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Drawing;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class MappingSetCreateExcelAccess : ExcelAccessCreate<MappingTagList>
    {
        protected override MappingTagList ReadWriteExcelData(ExcelPackage package)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Sheet1");

            PrepareSheet(ws);

            ws.Cells["A1:Y1"].AutoFitColumns();
            package.Save();
            return null;
        }

        private static void PrepareSheet(ExcelWorksheet ws)
        {
            ws.Cells["A1"].Value = "MappingTag";

            ws.Cells["A2"].Value = "Name";
            ws.Cells["B2"].Value = "Presentation Name";
            ws.Cells["C2"].Value = "Presentation Name";
            ws.Cells["D2"].Value = "Presentation Name";
            ws.Cells["E2"].Value = "Presentation Name";
            ws.Cells["F2"].Value = "SIType";
            ws.Cells["G2"].Value = "DataType";
            ws.Cells["H2"].Value = "Description";
            ws.Cells["I2"].Value = "SourceItemIdentifier";
            ws.Cells["J2"].Value = "SourceItemType";
            ws.Cells["K2"].Value = "SIType\r\n(depricated)";
            ws.Cells["L2"].Value = "CollectorType";
            ws.Cells["M2"].Value = "ScaleFactor";
            ws.Cells["N2"].Value = "ScaleOffset";
            ws.Cells["O2"].Value = "Operation";
            ws.Cells["P2"].Value = "IsStatusTag\r\n(depricated)";
            ws.Cells["Q2"].Value = "QualityCondition\r\n(depricated)";
            ws.Cells["R2"].Value = "ExpressionModel";
            ws.Cells["S2"].Value = "Type";
            ws.Cells["T2"].Value = "MappingSetTagValueId";
            ws.Cells["U2"].Value = "Expression";
            ws.Cells["V2"].Value = "Type";
            ws.Cells["W2"].Value = "MappingSetTagValueId";
            ws.Cells["X2"].Value = "Expression";
            ws.Cells["Y2"].Value = "TagMapping";

            ws.Cells["A1:H2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["A1:H2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(@"#90EE90"));
            ws.Cells["A1:H1"].Merge = true;
        }
    }
}
