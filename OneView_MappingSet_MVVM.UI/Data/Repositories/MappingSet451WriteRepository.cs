using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class MappingSet451WriteRepository : ExcelRepository<MappingTagList, MappingSet451CreateExcelAccess>, IMappingSetWriteRepository
    {
        public MappingSet451WriteRepository(MappingSet451CreateExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task WriteDataAsync(string path, MappingTagList data)
        {
            await ExcelAccess.WriteExcelDataAsync(path, data);
        }
    }
}
