using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class MappingSet450WriteRepository : ExcelRepository<MappingTagList, MappingSet450CreateExcelAccess>, IMappingSetWriteRepository
    {
        public MappingSet450WriteRepository(MappingSet450CreateExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task WriteDataAsync(string path, MappingTagList data)
        {
            await ExcelAccess.WriteExcelDataAsync(path, data);
        }
    }
}
