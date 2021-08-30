using OneView_MappingSet_MVVM.Model.Item;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public MappingTagList GetMappingSet(StandardTagList standardTagList, SourceItemDictionary sourceItemDictionary, SourceItemList sourceItemList, string turbineType)
        {
            var mappingTagList = new MappingTagList();

            var oneTypeDictionary = sourceItemDictionary.SourceDataList
                .Where(x => x.TurbineType == turbineType).ToList();

            // Find source item identifires
            var sourceItems = oneTypeDictionary
                .Where(si => sourceItemList.SourceDataList.Any(sil => sil.SourceItemIdentifier == si.SourceItemIdentifier)).ToList();
            foreach (var si in sourceItems)
            {
                var mappingTag = new MappingTag();
                DictionaryItemToMappingTag(si, mappingTag);
                mappingTagList.SourceDataList.Add(mappingTag);
            }

            // Find valid functions in chosen turbine type
            var functionTags = oneTypeDictionary
                .Where(f => !string.IsNullOrWhiteSpace(f.ReadExpression) || !string.IsNullOrWhiteSpace(f.WriteExpression))
                .ToList();
            var functionAndFoundTagnames = functionTags.Select(f => f.Tagname).ToList();
            functionAndFoundTagnames.AddRange(mappingTagList.SourceDataList.Select(s => s.Tagname).ToList());
            foreach (var f in functionTags)
            {
                var tagOk = true;
                const string regexGroupName = "tag";
                var regexPattern = $@"\( *\""(?<{regexGroupName}>.*?)\"""; // Take matches like ("<tagname>")
                if (!string.IsNullOrWhiteSpace(f.ReadExpression))
                {
                    var m = Regex.Matches(f.ReadExpression, regexPattern);
                    var matches = Regex.Matches(f.ReadExpression, regexPattern).Select(m => m.Groups[regexGroupName].Value).ToList();
                    if(!matches.All(m => functionAndFoundTagnames.Contains(m)))
                    {
                        tagOk = false;
                    }
                }
                if (!string.IsNullOrWhiteSpace(f.WriteExpression))
                {
                    var m = Regex.Matches(f.WriteExpression, regexPattern);
                    var matches = Regex.Matches(f.WriteExpression, regexPattern).Select(m => m.Groups[regexGroupName].Value).ToList();
                    if (!matches.All(m => functionAndFoundTagnames.Contains(m)))
                    {
                        tagOk = false;
                    }
                }
                if (tagOk)
                {
                    var mappingTag = new MappingTag();
                    DictionaryItemToMappingTag(f, mappingTag);
                    mappingTagList.SourceDataList.Add(mappingTag);
                }
            }

            // Add informations from Standard Tag List  
            if (standardTagList?.SourceDataList != null && standardTagList.SourceDataList.Count > 0)
            {
                foreach (var mt in mappingTagList.SourceDataList)
                {
                    Iec6140025TagToMappingTag(standardTagList.SourceDataList.FirstOrDefault(s => s.Tagname == mt.Tagname), mt);
                }
            }

            return mappingTagList;
        }
        public async Task<MappingTagList> GetMappingSetAsync(StandardTagList standardTagList, SourceItemDictionary sourceItemDictionary, SourceItemList sourceItemList, string turbineType)
        {
            return await Task.Run(() => GetMappingSet(standardTagList, sourceItemDictionary, sourceItemList, turbineType));
        }

        private void Iec6140025TagToMappingTag(Iec6140025Tag iecTag, MappingTag mappingTag)
        {
            mappingTag.PresentationNameEnglish = iecTag.PresentationNameEnglish;
            mappingTag.PresentationNameGerman = iecTag.PresentationNameGerman;
            mappingTag.PresentationNameSpanish = iecTag.PresentationNameSpanish;
            mappingTag.PresentationNamePolish = iecTag.PresentationNamePolish;
            mappingTag.SiType = iecTag.OvSiType;
            mappingTag.DataType = iecTag.DataType;
            mappingTag.Description = iecTag.Description;
        }

        private void DictionaryItemToMappingTag(DictionaryItem dictionaryItem, MappingTag mappingTag)
        {
            mappingTag.Tagname = dictionaryItem.Tagname;
            mappingTag.SourceItemIdentifier = dictionaryItem.SourceItemIdentifier;
            mappingTag.SourceItemType = dictionaryItem.SourceItemType;
            mappingTag.SiType = dictionaryItem.SiType;
            mappingTag.CollectorType = dictionaryItem.CollectorType;
            mappingTag.ScaleFactor = dictionaryItem.ScaleFactor;
            mappingTag.ScaleOffset = dictionaryItem.ScaleOffset;
            mappingTag.Operation = dictionaryItem.Operation;
            mappingTag.IsStatusTag = dictionaryItem.IsStatusTag;
            mappingTag.ConsiderConditions = dictionaryItem.ConsiderConditions;
            mappingTag.QualityCondition = dictionaryItem.QualityCondition;
            mappingTag.ConsiderValue = dictionaryItem.ConsiderValue;
            mappingTag.ValueCondition = dictionaryItem.ValueCondition;
            mappingTag.Operation = dictionaryItem.Operation;
            mappingTag.ExpressionModel = dictionaryItem.ExpressionModel;
            mappingTag.ReadExpressionType = dictionaryItem.ReadExpressionType;
            mappingTag.ReadExpressionMappingSetTagValueId = dictionaryItem.ReadExpressionMappingSetTagValueId;
            mappingTag.ReadExpression = dictionaryItem.ReadExpression;
            mappingTag.WriteExpressionType = dictionaryItem.WriteExpressionType;
            mappingTag.WriteExpressionMappingSetTagValueId = dictionaryItem.WriteExpressionMappingSetTagValueId;
            mappingTag.WriteExpression = dictionaryItem.WriteExpression;
            mappingTag.TagMapping = dictionaryItem.TagMapping;
        }
    }
}
