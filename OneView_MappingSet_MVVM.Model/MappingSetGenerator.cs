using OneView_MappingSet_MVVM.Model.ItemsList;
using OneView_MappingSet_MVVM.Model.Item;
using System.Collections.Generic;
using System.Linq;
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

        public IList<string> GetTurbineTypes(SourceItemDictionary input)
        {
            return input.SourceDataList.Select(t => t.TurbineType).Distinct().ToList();
        }
        public async Task<IList<string>> GetTurbineTypesAsync(SourceItemDictionary input)
        {
            return await Task.Run(() => GetTurbineTypes(input));
        }

        public MappingTagList GetMappingSet(StandardTagList standardTagList, SourceItemDictionary sourceItemDictionary, SourceItemList sourceItemList)
        {
            var mappingTagList = new MappingTagList();

            mappingTagList.SourceDataList.Add(new MappingTag() { Tagname = "Test1", CollectorType= "TenMinuteData" });
            mappingTagList.SourceDataList.Add(new MappingTag() { Tagname = "Test2"});

            return mappingTagList;
        }
        public async Task<MappingTagList> GetMappingSetAsync(StandardTagList standardTagList, SourceItemDictionary sourceItemDictionary, SourceItemList sourceItemList)
        {
            return await Task.Run(() => GetMappingSet(standardTagList, sourceItemDictionary, sourceItemList));
        }
    }
}
