using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using OneView_MappingSet_MVVM.Model.ItemsList;

namespace OneView_MappingSet_MVVM.UI.Data.Services
{
    public interface IMappingSetGeneratorService
    {
        Task<ExcelFileType> GetExcelFileTypeAsync(IList<string> sheetList);
        Task<IList<string>> GetTurbineTypesAsync(SourceItemDictionary sid);
        Task<MappingTagList> GetMappingSetAsync(StandardTagList standardTagList, SourceItemDictionary sourceItemDictionary, SourceItemList sourceItemList, string turbineType);
    }
}