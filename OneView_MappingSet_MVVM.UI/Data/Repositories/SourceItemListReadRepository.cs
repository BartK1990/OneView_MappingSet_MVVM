using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class SourceItemListReadRepository : ExcelRepository<SourceItemList, SourceItemListReadExcelAccess>, ISourceItemListReadRepository
    {
        public SourceItemListReadRepository(SourceItemListReadExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task<SourceItemList> ReadDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
