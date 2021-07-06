using OneView_MappingSet_MVVM.Model;
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
    }
}
