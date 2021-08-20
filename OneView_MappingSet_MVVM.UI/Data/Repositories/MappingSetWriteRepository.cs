using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class MappingSetWriteRepository : ExcelRepository<MappingTagList, MappingSetCreateExcelAccess>, IMappingSetWriteRepository
    {
        public MappingSetWriteRepository(MappingSetCreateExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task WriteDataAsync(string path)
        {
            await ExcelAccess.WriteExcelDataAsync(path);
        }
    }
}
