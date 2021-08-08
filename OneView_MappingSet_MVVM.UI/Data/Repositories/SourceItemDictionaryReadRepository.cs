using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class SourceItemDictionaryReadRepository : ExcelRepository<SourceItemDictionary, SourceItemDictionaryReadExcelAccess>, ISourceItemDictionaryReadRepository
    {
        public SourceItemDictionaryReadRepository(SourceItemDictionaryReadExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task<SourceItemDictionary> ReadDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
