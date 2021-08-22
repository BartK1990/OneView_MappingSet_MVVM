using OfficeOpenXml;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessRead<T>: ExcelAccess<T>
    {
        protected abstract T GetExcelData(ExcelPackage package);

        protected T GetExcelDataUsingWrapper(ExcelPackage package)
        {
            using (package)
            {
                return GetExcelData(package);
            }
        }

        public T ReadExcelData(string path)
        {
            return GetExcelDataUsingWrapper(GetExcelPackage(path));
        }
        public T ReadExcelData(ExcelPackage package)
        {
            return GetExcelDataUsingWrapper(package);
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
