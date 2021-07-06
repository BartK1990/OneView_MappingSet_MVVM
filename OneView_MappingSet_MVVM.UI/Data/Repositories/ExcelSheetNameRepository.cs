using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class ExcelSheetNameRepository : ExcelRepository<ExcelSheetName, SheetNamesExcelAccess>, IExcelSheetNameRepository
    {
        public ExcelSheetNameRepository(SheetNamesExcelAccess excelAccess) : base(excelAccess)
        {
        }

        public override async Task<ExcelSheetName> GetDataAsync(string path)
        {
            return await ExcelAccess.GetExcelDataAsync(path);
        }
    }
}
