using OfficeOpenXml;
using OneView_MappingSet_MVVM.Model;
using System.Linq;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class SourceItemListReadExcelAccess : SheetSpecificDataReadExcelAccess<SourceItemList, SourceItem>
    {
        public SourceItemListReadExcelAccess()
        {
            SheetName = MappingSetGenerator.SourceItemListSheetName; // Sheet name used in base class in GetExcelData
            // Excel sheet columns to read
            columnsNamesToClassDict.Add("SourceItemIdentifier", "SourceItemIdentifier");
        }

        protected override SourceItemList ReadSheetData(ExcelWorksheet worksheet)
        {
            var sourceItemList = new SourceItemList();
            var sheetDataList = sourceItemList.SourceDataList;

            ReadSheetSpecificData(worksheet, sheetDataList);
            return sourceItemList;
        }

        protected override SourceItem GetItem()
        {
            return new SourceItem();
        }

        protected override int RequiredColumnNumber()
        {
            return _columnsNumbersToStructDict.FirstOrDefault(v => v.Value == "SourceItemIdentifier").Key;
        }

    }

}
