using OfficeOpenXml;
using OneView_MappingSet_MVVM.Model;
using System.Linq;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class SourceItemDictionaryExcelAccess : SheetSpecificDataReadExcelAccess<SourceItemDictionary, DictionaryItem>
    {
        public SourceItemDictionaryExcelAccess()
        {
            SheetName = MappingSetGenerator.SourceItemDictionarySheetName; // Sheet name used in base class in GetExcelData
            // Excel sheet columns to read
            columnsNamesToStructDict.Add("Turbine Type", "TurbineType");
            columnsNamesToStructDict.Add("OneView IEC 61400-25-2 Edition 2", "Tagname");
            columnsNamesToStructDict.Add("SourceItemIdentifier", "SourceItemIdentifier");
            columnsNamesToStructDict.Add("SourceItemType", "SourceItemType ");
            columnsNamesToStructDict.Add("SIType", "SiType ");
            columnsNamesToStructDict.Add("CollectorType", "CollectorType ");
            columnsNamesToStructDict.Add("ScaleFactor", "ScaleFactor");
            columnsNamesToStructDict.Add("ScaleOffset", "ScaleOffset");
            columnsNamesToStructDict.Add("Operation", "Operation");
            columnsNamesToStructDict.Add("IsStatusTag", "IsStatusTag");
            columnsNamesToStructDict.Add("ConsiderConditions", "ConsiderConditions");
            columnsNamesToStructDict.Add("QualityCondition", "QualityCondition");
            columnsNamesToStructDict.Add("ConsiderValue", "ConsiderValue");
            columnsNamesToStructDict.Add("ValueCondition", "ValueCondition");
            columnsNamesToStructDict.Add("ExpressionModel", "ExpressionModel");
            columnsNamesToStructDict.Add("Read Expression Type", "ReadExpressionType");
            columnsNamesToStructDict.Add("Read Expression MappingSetTagValueId", "ReadExpressionMappingSetTagValueId");
            columnsNamesToStructDict.Add("Read Expression", "ReadExpression");
            columnsNamesToStructDict.Add("Write Expression Type", "WriteExpressionType");
            columnsNamesToStructDict.Add("Write Expression MappingSetTagValueId", "WriteExpressionMappingSetTagValueId");
            columnsNamesToStructDict.Add("Write Expression", "WriteExpression");
            columnsNamesToStructDict.Add("TagMapping", "TagMapping");
        }

        protected override SourceItemDictionary ReadSheetData(ExcelWorksheet worksheet)
        {
            var sourceItemList = new SourceItemDictionary();
            var sheetDataList = sourceItemList.SourceDataList;

            ReadSheetSpecificData(worksheet, sheetDataList);
            return sourceItemList;
        }

        protected override DictionaryItem GetItem()
        {
            return new DictionaryItem();
        }

        protected override int RequiredColumnNumber()
        {
            return _columnsNumbersToStructDict.FirstOrDefault(v => v.Value == "Tagname").Key;
        }
    }
}
