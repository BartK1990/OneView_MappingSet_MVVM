using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.UI.Data.Services
{
    public interface IMappingSetGeneratorService
    {
        Task<ExcelFileType> GetExcelFileTypeAsync(IList<string> sheetList);
    }
}