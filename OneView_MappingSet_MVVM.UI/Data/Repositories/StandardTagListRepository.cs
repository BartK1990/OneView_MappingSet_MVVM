using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    using OneView_MappingSet_MVVM.DataAccess;
    using OneView_MappingSet_MVVM.Model;

    public class StandardTagListRepository : ExcelRepository<StandardTagList, StandardTagListExcelAccess> , IStandardTagListRepository
    {
        public StandardTagListRepository(StandardTagListExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public override async Task<StandardTagList> GetDataAsync(string path)
        {
            return await ExcelAccess.GetStandardMappingSetAsync(path);
        }
    }
}
