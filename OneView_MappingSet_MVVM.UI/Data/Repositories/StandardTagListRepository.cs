using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    using OneView_MappingSet_MVVM.DataAccess;
    using OneView_MappingSet_MVVM.Model;

    public class StandardTagListRepository : IStandardTagListRepository
    {
        private StandardTagListExcelAccess ExcelAccess;

        public StandardTagListRepository(StandardTagListExcelAccess excelAccess)
        {
            ExcelAccess = excelAccess;
        }

        public async Task<StandardTagList> GetDataAsync(string path)
        {
            return await ExcelAccess.GetStandardMappingSetAsync(path);
        }
    }
}
