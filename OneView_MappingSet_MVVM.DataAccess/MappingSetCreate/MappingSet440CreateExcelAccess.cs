using OfficeOpenXml;
using OfficeOpenXml.Style;
using OneView_MappingSet_MVVM.DataAccess.MappingSetCreate;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Collections.Generic;
using System.Drawing;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class MappingSet440CreateExcelAccess : ExcelAccessCreate<MappingTagList>
    {
        private static readonly List<MappingSetExcelColumn> MappingSetExcelColumns = new List<MappingSetExcelColumn>
        {
             { new MappingSetExcelColumn(1, mappingTagPropertyName: "Tagname", "Name", "Green") }
            ,{ new MappingSetExcelColumn(2, mappingTagPropertyName: "PresentationNameEnglish", "PresentationName", "Green") }
            ,{ new MappingSetExcelColumn(3, mappingTagPropertyName: "SiType", "SIType", "Green") }
            ,{ new MappingSetExcelColumn(4, mappingTagPropertyName: "DataType", "DataType", "Green") }
            ,{ new MappingSetExcelColumn(5, mappingTagPropertyName: "Description", "Description", "Green") }
            ,{ new MappingSetExcelColumn(6, mappingTagPropertyName: "SourceItemIdentifier", "SourceItemIdentifier", "Green") }
            ,{ new MappingSetExcelColumn(7, mappingTagPropertyName: "SourceItemType", "SourceItemType", "Green") }
            ,{ new MappingSetExcelColumn(8, mappingTagPropertyName: "SiType", "SIType", "Green") }
            ,{ new MappingSetExcelColumn(9, mappingTagPropertyName: "CollectorType", "CollectorType", "Green") }
            ,{ new MappingSetExcelColumn(10, mappingTagPropertyName: "ScaleFactor", "ScaleFactor", "Green") }
            ,{ new MappingSetExcelColumn(11, mappingTagPropertyName: "ScaleOffset", "ScaleOffset", "Green") }
            ,{ new MappingSetExcelColumn(12, mappingTagPropertyName: "Operation", "Operation", "Green") }
            ,{ new MappingSetExcelColumn(13, mappingTagPropertyName: "IsStatusTag", "IsStatusTag", "Green") }
            ,{ new MappingSetExcelColumn(14, mappingTagPropertyName: "ConsiderConditions", "ConsiderConditions", "Green") }
            ,{ new MappingSetExcelColumn(15, mappingTagPropertyName: "QualityCondition", "QualityCondition", "Green") }
            ,{ new MappingSetExcelColumn(16, mappingTagPropertyName: "ConsiderValue", "ConsiderValue", "Green") }
            ,{ new MappingSetExcelColumn(17, mappingTagPropertyName: "ValueCondition", "ValueCondition", "Green") }
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
                ws.Cells[1, 1].Value = "MappingTag";
                ws.Cells[1, 1, 1, 5].Merge = true;
                ws.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

                ws.Cells[1, 19].Value = "ExpressionModel2123";
                ws.Cells[1, 19, 1, 21].Merge = true;
                ws.Cells[1, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[1, 19].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

                ws.Cells[1, 22].Value = "WriteExpression";
                ws.Cells[1, 22, 1, 24].Merge = true;
                ws.Cells[1, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[1, 22].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(greenHtmlColor));

                foreach (var mappingSetCol in MappingSetExcelColumns)
                {
                    mappingSetCol.FormatCells(ws);
                }

                // Border
                ws.Cells[2, 1, 2, 25].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[2, 1, 2, 25].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[2, 1, 2, 25].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[2, 1, 2, 25].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }
        }
    }
}
