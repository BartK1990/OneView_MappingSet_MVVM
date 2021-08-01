using System.IO;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessRead<T>: ExcelAccess<T>
    {
        public T ReadExcelData(string path)
        {
            return GetExcelPackage(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public async Task<T> ReadExcelDataAsync(string path)
        {
            return await Task.Run(() => ReadExcelData(path));
        }
    }
}
