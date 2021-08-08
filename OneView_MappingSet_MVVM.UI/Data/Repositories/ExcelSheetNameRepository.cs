using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class ExcelSheetNameRepository : ExcelRepository<ExcelSheetName, SheetNamesReadExcelAccess>, IExcelSheetNameRepository
    {
        public ExcelSheetNameRepository(SheetNamesReadExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public async Task<ExcelSheetName> ReadDataAsync(string path)
        {
            return await ExcelAccess.ReadExcelDataAsync(path);
        }
    }
}
