using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class StandardTagListRepository : ExcelRepository<StandardTagList, StandardTagListExcelAccess> , IStandardTagListRepository
    {
        public StandardTagListRepository(StandardTagListExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public override async Task<StandardTagList> ExchangeDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
