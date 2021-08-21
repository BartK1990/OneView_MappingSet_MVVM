using OneView_MappingSet_MVVM.Model;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Services
{
    public class MappingSetGeneratorService : IMappingSetGeneratorService
    {
        private readonly MappingSetGenerator _mappingSetGenerator;

        public MappingSetGeneratorService(MappingSetGenerator mappingSetGenerator)
        {
            this._mappingSetGenerator = mappingSetGenerator;
        }

        public async Task<ExcelFileType> GetExcelFileTypeAsync(IList<string> sheetList)
        {
            return await _mappingSetGenerator.CheckIfConatainsValidSheetAsync(sheetList);
        }

        public async Task<IList<string>> GetTurbineTypesAsync(SourceItemDictionary sid)
        {
            return await _mappingSetGenerator.GetTurbineTypesAsync(sid);
        }

        public async Task<MappingTagList> GetMappingSetAsync(StandardTagList standardTagList, SourceItemDictionary sourceItemDictionary, SourceItemList sourceItemList)
        {
            return await _mappingSetGenerator.GetMappingSetAsync(standardTagList, sourceItemDictionary, sourceItemList);
        }
    }
}
