using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class SourceItemListRepository : ExcelRepository<SourceItemList, SourceItemListExcelAccess>, ISourceItemListRepository
    {
        public SourceItemListRepository(SourceItemListExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public override async Task<SourceItemList> ExchangeDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
