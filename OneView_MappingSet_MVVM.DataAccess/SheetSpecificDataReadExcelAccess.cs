using OfficeOpenXml;
using OneView_MappingSet_MVVM.DataAccess.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class SheetSpecificDataReadExcelAccess<T,TItem> : SheetDataReadExcelAccess<T>
    {
        protected readonly Dictionary<string, string> columnsNamesToStructDict = new Dictionary<string, string>();

        protected Dictionary<int, string> _columnsNumbersToStructDict;

        protected void ReadSheetSpecificData(ExcelWorksheet worksheet, IList<TItem> sheetDataList)
        {
            int maxRow = worksheet.Dimension.Rows;
            int maxColumn = worksheet.Dimension.Columns;

            // Recognize column number
            _columnsNumbersToStructDict = new Dictionary<int, string>();
            for (int colNumCnt = 1; colNumCnt <= maxColumn; colNumCnt++)
            {
                var cellValue = GetCellValue(worksheet.Cells[1, colNumCnt].Value);
                if (columnsNamesToStructDict.ContainsKey(cellValue))
                {
                    _columnsNumbersToStructDict.Add(colNumCnt, columnsNamesToStructDict[cellValue]);
                }
                if (columnsNamesToStructDict.Count <= _columnsNumbersToStructDict.Count) // If all columns found stop searching
                {
                    break;
                }
            }

            if (columnsNamesToStructDict.Count > _columnsNumbersToStructDict.Count) // If not all columns found file is invalid - return empty collection
            {
                var missingColumns = columnsNamesToStructDict.Values.Except(_columnsNumbersToStructDict.Values);
                var exMessage = missingColumns.Aggregate((a, b) => $"{a}, {b}");
                throw new InvalidExcelSheetException($"There are missing columns in the worksheet: {exMessage}");
            }
            int requiredColumnNumber = RequiredColumnNumber();
            for (int rowNumCnt = 2; rowNumCnt <= maxRow; rowNumCnt++)
            {
                // If required column is empty go next row
                if (string.IsNullOrEmpty(GetCellValue(worksheet.Cells[rowNumCnt, requiredColumnNumber].Value)))
                    continue;

                TItem item = GetItem();
                foreach (int columnNum in _columnsNumbersToStructDict.Keys)
                {
                    string str = GetCellValue(worksheet.Cells[rowNumCnt, columnNum].Value);
                    if (!string.IsNullOrEmpty(str))
                    {
                        // Reflection
                        PropertyInfo iecTagPI = typeof(TItem).GetProperty(_columnsNumbersToStructDict[columnNum]);
                        if (iecTagPI != null)
                        {
                            iecTagPI.SetValue(item, str);
                        }
                    }
                }
                sheetDataList.Add(item);
            }
            if (sheetDataList?.Any() == false)
            {
                throw new InvalidExcelSheetException("Worksheet does not contain any data");
            }
        }

        protected abstract int RequiredColumnNumber();

        protected abstract TItem GetItem();

    }
}
