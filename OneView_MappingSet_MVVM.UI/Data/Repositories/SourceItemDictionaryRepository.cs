using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class SourceItemDictionaryRepository : ExcelRepository<SourceItemDictionary, SourceItemDictionaryExcelAccess>, ISourceItemDictionaryRepository
    {
        public SourceItemDictionaryRepository(SourceItemDictionaryExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public override async Task<SourceItemDictionary> ExchangeDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
