using OfficeOpenXml;
using OneView_MappingSet_MVVM.Model;
using System.Linq;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class SourceItemDictionaryReadExcelAccess : SheetSpecificDataReadExcelAccess<SourceItemDictionary, DictionaryItem>
    {
        public SourceItemDictionaryReadExcelAccess()
        {
            SheetName = MappingSetGenerator.SourceItemDictionarySheetName; // Sheet name used in base class in GetExcelData
            // Excel sheet columns to read
            columnsNamesToClassDict.Add("Turbine Type", "TurbineType");
            columnsNamesToClassDict.Add("OneView IEC 61400-25-2 Edition 2", "Tagname");
            columnsNamesToClassDict.Add("SourceItemIdentifier", "SourceItemIdentifier");
            columnsNamesToClassDict.Add("SourceItemType", "SourceItemType ");
            columnsNamesToClassDict.Add("SIType", "SiType ");
            columnsNamesToClassDict.Add("CollectorType", "CollectorType ");
            columnsNamesToClassDict.Add("ScaleFactor", "ScaleFactor");
            columnsNamesToClassDict.Add("ScaleOffset", "ScaleOffset");
            columnsNamesToClassDict.Add("Operation", "Operation");
            columnsNamesToClassDict.Add("IsStatusTag", "IsStatusTag");
            columnsNamesToClassDict.Add("QualityCondition", "QualityCondition");
            columnsNamesToClassDict.Add("ExpressionModel", "ExpressionModel");
            columnsNamesToClassDict.Add("Read Expression Type", "ReadExpressionType");
            columnsNamesToClassDict.Add("Read Expression MappingSetTagValueId", "ReadExpressionMappingSetTagValueId");
            columnsNamesToClassDict.Add("Read Expression", "ReadExpression");
            columnsNamesToClassDict.Add("Write Expression Type", "WriteExpressionType");
            columnsNamesToClassDict.Add("Write Expression MappingSetTagValueId", "WriteExpressionMappingSetTagValueId");
            columnsNamesToClassDict.Add("Write Expression", "WriteExpression");
            columnsNamesToClassDict.Add("TagMapping", "TagMapping");
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
