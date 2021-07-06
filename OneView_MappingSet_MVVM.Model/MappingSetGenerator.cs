using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.Model
{
    public enum ExcelFileType
    {
        Invalid = -1
        , StandardTagList = 1
        , SourceDictionary = 2
        , SourceList = 3
    }

    public class MappingSetGenerator
    {
        public const string StandardTagListSheetName = "SCI Standard Mappingset";
        public const string SourceItemDictionarySheetName = "SCI Source Dictionary";
        public const string SourceItemListSheetName = "SCI Source Items";

        public ExcelFileType CheckIfConatainsValidSheet(IList<string> sheetCollection) 
        {
            if(sheetCollection is null)
                return ExcelFileType.Invalid;

            foreach (string sheetName in sheetCollection)
            {
                switch (sheetName)
                {
                    case(StandardTagListSheetName):
                        return ExcelFileType.StandardTagList;
                    case (SourceItemDictionarySheetName):
                        return ExcelFileType.SourceDictionary;
                    case (SourceItemListSheetName):
                        return ExcelFileType.SourceList;
                    default:
                        break;
                }
            }
            return ExcelFileType.Invalid;
        }

        public async Task<ExcelFileType> CheckIfConatainsValidSheetAsync(IList<string> sheetCollection)
        {
            return await Task.Run(() => CheckIfConatainsValidSheet(sheetCollection));
        }
    }
}
