using OfficeOpenXml;
using OfficeOpenXml.Style;
using OneView_MappingSet_MVVM.DataAccess.MappingSetCreate;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Collections.Generic;
using System.Drawing;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class MappingSet450CreateExcelAccess : ExcelAccessCreate<MappingTagList>
    {
        private static readonly List<MappingSetExcelColumn> MappingSetExcelColumns = new List<MappingSetExcelColumn>
        {
             { new MappingSetExcelColumn(1, mappingTagPropertyName: "Tagname", "Name", "Green") }
            ,{ new MappingSetExcelColumn(2, mappingTagPropertyName: "PresentationNameEnglish", "Presentation Name\n(English)", "Green") }
            ,{ new MappingSetExcelColumn(3, mappingTagPropertyName: string.Empty, "Presentation Name\n(German)", "Green") }
            ,{ new MappingSetExcelColumn(4, mappingTagPropertyName: string.Empty, "Presentation Name\n(Spanish)", "Green") }
            ,{ new MappingSetExcelColumn(5, mappingTagPropertyName: string.Empty, "Presentation Name\n(Polish)", "Green") }
            ,{ new MappingSetExcelColumn(6, mappingTagPropertyName: "SiType", "SIType", "Green") }
            ,{ new MappingSetExcelColumn(7, mappingTagPropertyName: "DataType", "DataType", "Green") }
            ,{ new MappingSetExcelColumn(8, mappingTagPropertyName: "Description", "Description", "Green") }
            ,{ new MappingSetExcelColumn(9, mappingTagPropertyName: "SourceItemIdentifier", "SourceItemIdentifier", "Green") }
            ,{ new MappingSetExcelColumn(10, mappingTagPropertyName: "SourceItemType", "SourceItemType", "Green") }
            ,{ new MappingSetExcelColumn(11, mappingTagPropertyName: string.Empty, "SIType\n(depricated)", "Red") }
            ,{ new MappingSetExcelColumn(12, mappingTagPropertyName: "CollectorType", "CollectorType", "Green") }
            ,{ new MappingSetExcelColumn(13, mappingTagPropertyName: "ScaleFactor", "ScaleFactor", "Green") }
            ,{ new MappingSetExcelColumn(14, mappingTagPropertyName: "ScaleOffset", "ScaleOffset", "Green") }
            ,{ new MappingSetExcelColumn(15, mappingTagPropertyName: "Operation", "Operation", "Green") }
            ,{ new MappingSetExcelColumn(16, mappingTagPropertyName: string.Empty, "IsStatusTag\n(depricated)", "Red") }
            ,{ new MappingSetExcelColumn(17, mappingTagPropertyName: string.Empty, "QualityCondition\n(depricated)", "Red") }
            ,{ new MappingSetExcelColumn(18, mappingTagPropertyName: "ExpressionModel", "ExpressionModel", "Green") }
            ,{ new MappingSetExcelColumn(19, mappingTagPropertyName: "ReadExpressionType", "Type", "Green") }
            ,{ new MappingSetExcelColumn(20, mappingTagPropertyName: "ReadExpressionMappingSetTagValueId", "MappingSetTagValueId", "Green") }
            ,{ new MappingSetExcelColumn(21, mappingTagPropertyName: "ReadExpression", "Expression", "Green") }
            ,{ new MappingSetExcelColumn(22, mappingTagPropertyName: "WriteExpressionType", "Type", "Green") }
            ,{ new MappingSetExcelColumn(23, mappingTagPropertyName: "WriteExpressionType", "MappingSetTagValueId", "Green") }
            ,{ new MappingSetExcelColumn(24, mappingTagPropertyName: "WriteExpression", "Expression", "Green") }
            ,{ new MappingSetExcelColumn(25, mappingTagPropertyName: "TagMapping", "TagMapping", "Green") }
        };

        protected override void PutExcelData(ExcelPackage package, MappingTagList data)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Sheet1");

            PrepareSheet(ws);

            var currentRow = 2;
            foreach (var d in data.SourceDataList)
            {
                currentRow++;
                foreach (var mappingSetCol in MappingSetExcelColumns)
                {
                    mappingSetCol.UpdateRow(ws, currentRow, d);
                }
            }

            ws.Cells["A2:Y2"].AutoFilter = true;
            ws.Cells["A1:Y2"].AutoFitColumns();
            package.Save();
        }

        private static void PrepareSheet(ExcelWorksheet ws)
        {
            if (MappingSetExcelColumn.Colors.TryGetValue("Green", out var greenHtmlColor))
            {
                ws.Cells["A1"].Value = "MappingTag";
                ws.Cells["A1:H1"].Merge = true;
                ws.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["A1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

                ws.Cells["S1"].Value = "ExpressionModel2123";
                ws.Cells["S1:U1"].Merge = true;
                ws.Cells["S1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["S1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

                ws.Cells["V1"].Value = "WriteExpression";
                ws.Cells["V1:X1"].Merge = true;
                ws.Cells["V1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["V1"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

                foreach (var mappingSetCol in MappingSetExcelColumns)
                {
                    mappingSetCol.FormatCells(ws);
                }

                // Border
                ws.Cells["A2:Y2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells["A2:Y2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells["A2:Y2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells["A2:Y2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }
        }
    }
}
