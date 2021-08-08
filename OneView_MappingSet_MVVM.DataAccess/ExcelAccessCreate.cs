using System.IO;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessCreate<T> : ExcelAccess<T>
    {
        public void WriteExcelData(string path)
        {
            GetExcelPackage(path, FileMode.Create, FileAccess.Write, FileShare.None);
        }

        public async Task WriteExcelDataAsync(string path)
        {
            await Task.Run(() => WriteExcelData(path));
        }
    }
}
