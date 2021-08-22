using OfficeOpenXml;
using OfficeOpenXml.Style;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Drawing;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class MappingSetCreateExcelAccess : ExcelAccessCreate<MappingTagList>
    {
        protected override void PutExcelData(ExcelPackage package, MappingTagList data)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Sheet1");
            PrepareSheet(ws);

            var currentRow = 2;
            foreach (var d in data.SourceDataList)
            {
                currentRow++;
                ws.Cells[currentRow, 1].Value = d.Tagname;
                ws.Cells[currentRow, 2].Value = d.PresentationName;

                ws.Cells[currentRow, 6].Value = d.SiType;
                ws.Cells[currentRow, 7].Value = d.DataType;
                ws.Cells[currentRow, 8].Value = d.Description;

                ws.Cells[currentRow, 9].Value = d.SourceItemIdentifier;
                ws.Cells[currentRow, 10].Value = d.SourceItemType;

                ws.Cells[currentRow, 12].Value = d.CollectorType;
                ws.Cells[currentRow, 13].Value = d.ScaleFactor;
                ws.Cells[currentRow, 14].Value = d.ScaleOffset;
                ws.Cells[currentRow, 15].Value = d.Operation;

                ws.Cells[currentRow, 18].Value = d.ExpressionModel;

                ws.Cells[currentRow, 19].Value = d.ReadExpressionType;
                ws.Cells[currentRow, 20].Value = d.ReadExpressionMappingSetTagValueId;
                ws.Cells[currentRow, 21].Value = d.ReadExpression;

                ws.Cells[currentRow, 22].Value = d.WriteExpressionType;
                ws.Cells[currentRow, 23].Value = d.WriteExpressionType;
                ws.Cells[currentRow, 24].Value = d.WriteExpression;

                ws.Cells[currentRow, 25].Value = d.TagMapping;
            }

            ws.Cells["A1:Y2"].AutoFitColumns();
            package.Save();
        }

        private static void PrepareSheet(ExcelWorksheet ws)
        {
            var greenHtmlColor = @"#90EE90";
            var redHtmlColor = @"#FFB6C1";

            ws.Cells["A1"].Value = "MappingTag";
            ws.Cells["A1:H1"].Merge = true;

            ws.Cells["A2"].Value = "Name";
            ws.Cells["B2"].Value = "Presentation Name\n(English)";
            ws.Cells["C2"].Value = "Presentation Name\n(German)";
            ws.Cells["D2"].Value = "Presentation Name\n(Spanish)";
            ws.Cells["E2"].Value = "Presentation Name\n(Polish)";
            ws.Cells["F2"].Value = "SIType";
            ws.Cells["G2"].Value = "DataType";
            ws.Cells["H2"].Value = "Description";

            ws.Cells["A1:H2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["A1:H2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));
            
            ws.Cells["I2"].Value = "SourceItemIdentifier";
            ws.Cells["J2"].Value = "SourceItemType";
            ws.Cells["K2"].Value = "SIType\n(depricated)";
            ws.Cells["L2"].Value = "CollectorType";
            ws.Cells["M2"].Value = "ScaleFactor";
            ws.Cells["N2"].Value = "ScaleOffset";
            ws.Cells["O2"].Value = "Operation";
            ws.Cells["P2"].Value = "IsStatusTag\n(depricated)";
            ws.Cells["Q2"].Value = "QualityCondition\n(depricated)";
            ws.Cells["R2"].Value = "ExpressionModel";

            ws.Cells["I2:R2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["I2:J2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));
            ws.Cells["K2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(redHtmlColor));
            ws.Cells["L2:O2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));
            ws.Cells["P2:Q2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(redHtmlColor));
            ws.Cells["R2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

            ws.Cells["S1"].Value = "ExpressionModel2123";
            ws.Cells["S1:U1"].Merge = true;

            ws.Cells["S2"].Value = "Type";
            ws.Cells["T2"].Value = "MappingSetTagValueId";
            ws.Cells["U2"].Value = "Expression";

            ws.Cells["S1:U2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["S1:U2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

            ws.Cells["V1"].Value = "WriteExpression";
            ws.Cells["V1:X1"].Merge = true;

            ws.Cells["V2"].Value = "Type";
            ws.Cells["W2"].Value = "MappingSetTagValueId";
            ws.Cells["X2"].Value = "Expression";

            ws.Cells["V1:X2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["V1:X2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

            ws.Cells["Y2"].Value = "TagMapping";

            ws.Cells["Y2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells["Y2"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

            // Border
            ws.Cells["A2:Y2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells["A2:Y2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells["A2:Y2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells["A2:Y2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            ws.Cells["A2:Y2"].AutoFilter = true;
        }
    }
}
