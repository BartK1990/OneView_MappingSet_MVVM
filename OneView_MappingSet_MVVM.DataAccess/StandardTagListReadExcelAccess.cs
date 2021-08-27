using OfficeOpenXml;
using OneView_MappingSet_MVVM.Model;
using System.Linq;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public class StandardTagListReadExcelAccess : SheetSpecificDataReadExcelAccess<StandardTagList,Iec6140025Tag>
    {
        public StandardTagListReadExcelAccess()
        {
            SheetName = MappingSetGenerator.StandardTagListSheetName; // Sheet name used in base class in GetExcelData   
            // Excel sheet columns to read
            columnsNamesToClassDict.Add("OneView IEC 61400-25-2 Edition 2", "Tagname");
            columnsNamesToClassDict.Add("Presentation Name\n(English)", "PresentationNameEnglish");
            columnsNamesToClassDict.Add("Presentation Name\n(German)", "PresentationNameGerman");
            columnsNamesToClassDict.Add("Presentation Name\n(Spanish)", "PresentationNameSpanish");
            columnsNamesToClassDict.Add("Presentation Name\n(Polish)", "PresentationNamePolish");
            columnsNamesToClassDict.Add("Description", "Description");
            columnsNamesToClassDict.Add("OV SI Type", "OvSiType");
            columnsNamesToClassDict.Add("SI Unit", "SiUnit");
            columnsNamesToClassDict.Add("Type", "Type");
            columnsNamesToClassDict.Add("DataType", "DataType");
            columnsNamesToClassDict.Add("CollectorType", "CollectorType");
        }

        protected override StandardTagList ReadSheetData(ExcelWorksheet worksheet)
        {
            var sourceItemList = new StandardTagList();
            var sheetDataList = sourceItemList.SourceDataList;

            ReadSheetSpecificData(worksheet, sheetDataList);
            return sourceItemList;
        }

        protected override Iec6140025Tag GetItem()
        {
            return new Iec6140025Tag();
        }

        protected override int RequiredColumnNumber()
        {
            return _columnsNumbersToStructDict.FirstOrDefault(v => v.Value == "Tagname").Key;
        }
    }
    
}
