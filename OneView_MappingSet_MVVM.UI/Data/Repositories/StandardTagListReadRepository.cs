using System.Threading.Tasks;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class StandardTagListReadRepository : ExcelRepository<StandardTagList, StandardTagListReadExcelAccess> , IStandardTagListReadRepository
    {
        public StandardTagListReadRepository(StandardTagListReadExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task<StandardTagList> ReadDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
