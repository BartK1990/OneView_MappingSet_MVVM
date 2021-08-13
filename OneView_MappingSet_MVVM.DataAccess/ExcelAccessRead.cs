using OfficeOpenXml;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessRead<T>: ExcelAccess<T>
    {
        public T ReadExcelData(string path)
        {
            return GetExcelData(GetExcelPackage(path));
        }
        public T ReadExcelData(ExcelPackage package)
        {
            return GetExcelData(package);
        }

        public async Task<T> ReadExcelDataAsync(string path)
        {
            return await Task.Run(() => ReadExcelData(path));
        }
        public async Task<T> ReadExcelDataAsync(ExcelPackage package)
        {
            return await Task.Run(() => ReadExcelData(package));
        }
    }
}
