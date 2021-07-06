using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccess<T>
    {
        protected T GetExcelPackage(string path)
        {
            using (Stream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {             
                    return GetExcelData(package);
                }
            }
        }

        protected abstract T GetExcelData(ExcelPackage package);

        public T GetExcelData(string path)
        {
            return GetExcelPackage(path);
        }

        public async Task<T> GetExcelDataAsync(string path)
        {
            return await Task.Run(() => GetExcelData(path));
        }
    }
}
