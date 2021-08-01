using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class SourceItemListCreateRepository : ExcelRepository<SourceItemList, SourceItemListCreateExcelAccess>, ISourceItemListCreateRepository
    {
        public SourceItemListCreateRepository(SourceItemListCreateExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public override async Task<SourceItemList> ExchangeDataAsync(string path)
        {
            await ExcelAccess.WriteExcelDataAsync(path);
            return null;
        }
    }
}
