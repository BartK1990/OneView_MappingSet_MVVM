using System.IO;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessCreate<T> : ExcelAccess<T>
    {
        public T WriteExcelData(string path)
        {
            return GetExcelPackage(path, FileMode.Create, FileAccess.Write, FileShare.None);
        }

        public async Task<T> WriteExcelDataAsync(string path)
        {
            return await Task.Run(() => WriteExcelData(path));
        }
    }
}
