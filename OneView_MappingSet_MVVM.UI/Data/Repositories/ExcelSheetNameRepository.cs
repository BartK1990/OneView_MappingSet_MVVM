using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class ExcelSheetNameRepository : IExcelRepository<ExcelSheetName>
    {
        private readonly ExcelSheetNameAccess _excelAccess;

        public ExcelSheetNameRepository(ExcelSheetNameAccess excelAccess)
        {
            this._excelAccess = excelAccess;
        }

        public async Task<ExcelSheetName> GetDataAsync(string path)
        {
            return await _excelAccess.GetSheetNameAsync(path);
        }
    }
}
