using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    using OneView_MappingSet_MVVM.DataAccess;
    using OneView_MappingSet_MVVM.Model;

    public class StandardMappingSetRepository : IStandardMappingSetRepository
    {
        private StandardMappingSetExcelAccess ExcelAccess;

        public StandardMappingSetRepository(StandardMappingSetExcelAccess excelAccess)
        {
            ExcelAccess = excelAccess;
        }

        public async Task<StandardMappingSet> GetDataAsync(string path)
        {
            return await ExcelAccess.GetStandardMappingSetAsync(path);
        }
    }
}
