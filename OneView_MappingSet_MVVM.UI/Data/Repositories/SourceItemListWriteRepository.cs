using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class SourceItemListWriteRepository : ExcelRepository<SourceItemList, SourceItemListCreateExcelAccess>, ISourceItemListWriteRepository
    {
        public SourceItemListWriteRepository(SourceItemListCreateExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task WriteDataAsync(string path, SourceItemList data)
        {
            await ExcelAccess.WriteExcelDataAsync(path, data);
        }
    }
}
