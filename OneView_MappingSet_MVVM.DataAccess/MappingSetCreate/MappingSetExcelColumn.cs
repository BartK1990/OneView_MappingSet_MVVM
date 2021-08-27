using OfficeOpenXml;
using OfficeOpenXml.Style;
using OneView_MappingSet_MVVM.Model.Item;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace OneView_MappingSet_MVVM.DataAccess.MappingSetCreate
{
    internal class MappingSetExcelColumn
    {
        public static readonly Dictionary<string, string> Colors = new Dictionary<string, string>
        {
            { "Green", @"#90EE90" },
            { "Red", @"#FFB6C1" }
        };

        private const int firstRow = 2;

        private int _columnNumber;
        public int ColumnNumber 
        {
            get => this._columnNumber;
            set 
            {
                if (value > 0)
                {
                    this._columnNumber = value;
                }
                else
                {
                    this._columnNumber = 1;
                }
            }
        }
        private string _backgroundColor;
        public string BackgroundColor 
        { 
            get => _backgroundColor;
            set
            {
                if (Colors.ContainsKey(value))
                {
                    _backgroundColor = Colors[value];
                }
                else
                {
                    _backgroundColor = string.Empty;
                }
            }
        }
        private string _mappingTagPropertyName;
        private string _headerText;

        public MappingSetExcelColumn(int columnNumber, string mappingTagPropertyName, string headerText, string backgroundColor)
        {
            this.ColumnNumber = columnNumber;
            this.BackgroundColor = backgroundColor;
            this._mappingTagPropertyName = mappingTagPropertyName;
            this._headerText = headerText;
        }
        
        public void FormatCells(ExcelWorksheet excelWorksheet)
        {
            if (excelWorksheet == null || string.IsNullOrWhiteSpace(_backgroundColor))
                return;

            excelWorksheet.Cells[firstRow, _columnNumber].Style.Fill.PatternType = ExcelFillStyle.Solid;
            excelWorksheet.Cells[firstRow, _columnNumber].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(_backgroundColor));
            excelWorksheet.Cells[firstRow, _columnNumber].Value = _headerText;
        }

        public void UpdateRow(ExcelWorksheet excelWorksheet, int rowNum, MappingTag mappingTag)
        {
            if (excelWorksheet == null)
                return;
            if (rowNum <= 0)
                return;
            if (string.IsNullOrWhiteSpace(_mappingTagPropertyName))
                return;

            PropertyInfo mappingTagPI = typeof(MappingTag).GetProperty(_mappingTagPropertyName);
            excelWorksheet.Cells[rowNum, _columnNumber].Value = mappingTagPI.GetValue(mappingTag);
        }
    }
}
